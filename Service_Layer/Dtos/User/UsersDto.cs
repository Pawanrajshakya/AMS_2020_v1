using System.Collections.Generic;
using Service_Layer.Dtos;
using Service_Layer.Helpers;

public class UsersDto
{

    public UsersDto()
    {
        Users = new PagedList<UserDto>();
    }
    public PagedList<UserDto> Users { get; set; }
    public int TotalCount { get; set; }
    public int PageSize { get; set; }
    public int TotalPages { get; set; }
    public int CurrentPage { get; set; }
}