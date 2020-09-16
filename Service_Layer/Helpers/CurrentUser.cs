using Service_Layer.Dtos;

namespace Service_Layer.Helpers
{
    public class CurrentUser
    {
        private static UserDto _userDto;

        public static UserDto User
        {
            get
            {
                if (_userDto == null)
                    return new UserDto();

                return _userDto;
            }
            set
            {
                _userDto = value;
            }
        }
    }
}