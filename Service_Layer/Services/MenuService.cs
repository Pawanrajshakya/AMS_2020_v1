using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Persistence_Layer.Interfaces;
using Persistence_Layer.Models;
using Service_Layer.Dtos;
using Service_Layer.Dtos.Menu;
using Service_Layer.Helpers;
using Service_Layer.Interface;

namespace Service_Layer.Services
{
    public class MenuService : BaseService, IMenuService
    {

        public MenuService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<int> Add(MenuToSaveDto entity)
        {
            if (await _unitOfWork.Menu.Exists(x => x.Title == entity.Title))
            {
                throw new Exception("Already exists.");
            }

            Menu menu = _mapper.Map<Menu>(entity);

            _unitOfWork.Menu.Add(menu);

            _unitOfWork.Complete();

            return menu.Id;
        }

        public async Task<MenuDto> Get(int id)
        {
            var entity = await this._unitOfWork.Menu.Get(id);

            if (!entity.IsVisible)
                return null;


            MenuDto menuDto = _mapper.Map<MenuDto>(entity);

            if (!string.IsNullOrEmpty(entity.UserRoles))
            {
                var userRoleList = entity.UserRoles.Split(',').Select(int.Parse).ToList();
                foreach (var item in userRoleList)
                {
                    var role = await _unitOfWork.Role.Get(item);
                    menuDto.Roles.Add(_mapper.Map<RoleDto>(role));
                };
            }
            return menuDto;
        }

        public async Task<List<MenuDto>> Get()
        {
            List<MenuDto> menuDtos = new List<MenuDto>();

            var menus = await _unitOfWork.Menu.GetAll()
                .OrderBy(x => x.Title)
                .ToListAsync();

            if (menus != null)
            {
                foreach (var menu in menus)
                {
                    MenuDto dto = _mapper.Map<MenuDto>(menu);
                    menuDtos.Add(dto);
                }
            }

            return menuDtos;
        }

        public async Task<MenusDto> Get(Param parameters)
        {
            PagedList<MenuDto> menuDtos = new PagedList<MenuDto>();

            var queryable = _unitOfWork.Menu.GetAll()
                .Where(x => x.IsVisible == true);

            switch (parameters.SearchBy.ToLower())
            {
                case "description":
                    queryable = queryable.Where(x => x.Title.Contains(parameters.SearchText));
                    break;
            }

            switch (parameters.SortBy.ToLower())
            {
                case "description":
                    switch (parameters.SortDirection.ToLower())
                    {
                        case "desc":
                            queryable = queryable.OrderByDescending(x => x.Title);
                            break;
                        case "asc":
                            queryable = queryable.OrderBy(x => x.Title);
                            break;
                        default:
                            queryable = queryable.OrderByDescending(x => x.CreatedDate);
                            break;

                    }
                    break;
                case "createddate":
                    switch (parameters.SortDirection.ToLower())
                    {
                        case "desc":
                            queryable = queryable.OrderByDescending(x => x.CreatedDate);
                            break;
                        case "asc":
                            queryable = queryable.OrderBy(x => x.CreatedDate);
                            break;
                        default:
                            queryable = queryable.OrderByDescending(x => x.CreatedDate);
                            break;
                    }
                    break;
            }

            var pagedMenus = await PagedList<Menu>.CreateAsync(queryable, parameters.PageNumber, parameters.PageSize);

            if (pagedMenus != null)
            {
                foreach (var menu in pagedMenus)
                {
                    MenuDto dto = _mapper.Map<MenuDto>(menu);

                    if (!string.IsNullOrEmpty(menu.UserRoles))
                    {
                        var userRoleList = menu.UserRoles.Split(',').Select(int.Parse).ToList();
                        foreach (var item in userRoleList)
                        {
                            var role = await _unitOfWork.Role.Get(item);
                            dto.Roles.Add(_mapper.Map<RoleDto>(role));
                        };
                    }

                    if (menu.MainMenuId > 0)
                    {
                        var mainMenu = await _unitOfWork.Menu.Get(menu.MainMenuId);
                        dto.MainMenuName = mainMenu.Title;
                    }

                    menuDtos.Add(dto);
                }
            }

            MenusDto menus = new MenusDto();
            menus.Menus = menuDtos;
            menus.CurrentPage = pagedMenus.CurrentPage;
            menus.PageSize = pagedMenus.PageSize;
            menus.TotalCount = pagedMenus.TotalCount;
            menus.TotalPages = pagedMenus.TotalPages;
            return menus;
        }

        public List<MainMenusDto> GetMainMenus(int id)
        {
            return _unitOfWork
            .Menu
            .FindAll(x => (
                x.MainMenuId == 0
                && x.Id != id
                && x.IsActive
                && x.IsVisible))
            .Select(x => new MainMenusDto { Id = x.Id, Title = x.Title })
            .ToList();
        }

        public List<UserMenuDto> GetCurrentUserMenus()
        {

            var currentUserRoles = CurrentUser.User.UserRole;

            List<UserMenuDto> userMenuDtos = new List<UserMenuDto>();

            foreach (var role in currentUserRoles)
            {
                userMenuDtos = _unitOfWork.Menu
            .FindAll(
                x => x.UserRoles.Contains(role.Id.ToString())
                && x.IsActive
                && x.IsVisible
                )
                .Select(x => new UserMenuDto
                {
                    Id = x.Id,
                    Title = x.Title,
                    SortId = x.SortId,
                    IconName = x.IconName,
                    Link = x.Link,
                    MainMenuId = x.MainMenuId
                })
                .OrderBy(x => x.SortId)
                .ToList();
            }

            List<UserMenuDto> userMenuDtosOut = new List<UserMenuDto>();

            foreach (var menu in userMenuDtos.OrderBy(z => z.MainMenuId))
            {
                if (menu.MainMenuId == 0 && (userMenuDtosOut.Find(z => z.Id == menu.Id) == null))
                {
                    // if (userMenuDtos.Where(z => z.MainMenuId == menu.Id).Count() >= 1)
                    menu.SubMenu = new List<UserMenuDto>();

                    userMenuDtosOut.Add(menu);
                }
                else if (menu.MainMenuId != 0 && (userMenuDtosOut.Find(z => z.Id == menu.Id) == null))
                {
                    var index = userMenuDtosOut.FindIndex(z => z.Id == menu.MainMenuId);
                    userMenuDtosOut.ElementAt(index).SubMenu.Add(menu);
                }
            }

            return userMenuDtosOut;
        }

        public async Task<bool> Remove(int id)
        {
            var Menu = await this._unitOfWork.Menu.Get(id);

            if (Menu == null)
            {
                throw new Exception("Not Found.");
            }

            this._unitOfWork.Menu.Remove(Menu);

            if (_unitOfWork.Complete() > 0)
                return true;

            return false;
        }

        public async Task<bool> SoftDelete(int id)
        {
            var menuToDelete = await this._unitOfWork.Menu.Get(id);

            if (menuToDelete == null)
                throw new Exception("Not Found.");

            menuToDelete.IsVisible = false;
            menuToDelete.LastModifiedBy = CurrentUser.User.Id;
            menuToDelete.LastModifiedDate = DateTime.Now;

            this._unitOfWork.Menu.Update(menuToDelete);

            if (_unitOfWork.Complete() > 0)
                return true;

            return false;
        }

        public async Task<bool> Update(int id, MenuToEditDto entity)
        {
            var menuToUpdate = await this._unitOfWork.Menu.Get(id);

            if (menuToUpdate == null)
                throw new Exception("Not Found.");

            menuToUpdate.Title = entity.Title;
            menuToUpdate.IconName = entity.IconName;
            menuToUpdate.Link = entity.Link;
            menuToUpdate.MainMenuId = entity.MainMenuId;
            menuToUpdate.SortId = entity.SortId;
            menuToUpdate.UserRoles = entity.UserRoles;
            menuToUpdate.IsActive = entity.IsActive;
            menuToUpdate.LastModifiedBy = CurrentUser.User.Id;
            menuToUpdate.LastModifiedDate = DateTime.Now;

            _unitOfWork.Menu.Update(menuToUpdate);

            if (_unitOfWork.Complete() > 0)
                return true;

            return false;
        }
    }
}