using ECommerceModels.Enums;
using ECommerceDTOs;
namespace Shared.Helpers
{
    public static class SessionManager
    {
        public static int UserId { get; private set; }
        public static string Username { get; private set; }
        public static string Email { get; private set; }
        public static UserRole Role { get; private set; }

        public static DateTime LastLoginDate { get; private set; }
        public static IsActive IsActive { get; private set; }

        public static bool IsAuthenticated => UserId > 0;

        public static void SetSession(SessionUserDto userDto)
        {
            if (userDto == null) throw new ArgumentNullException(nameof(userDto));

            UserId = userDto.UserId;
            Username = userDto.Username;
            Email = userDto.Email;
            Role = userDto.Role;
            LastLoginDate = DateTime.Now;
            IsActive = userDto.IsActive;
        }


        public static void ClearSession()
        {
            UserId = 0;
            Username = null;
            Email = null;
        }
    }

}
