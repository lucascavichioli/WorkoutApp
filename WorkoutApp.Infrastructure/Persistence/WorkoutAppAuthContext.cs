using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WorkoutApp.Infrastructure.Persistence
{
    public class WorkoutAppAuthContext(DbContextOptions options) 
        : IdentityDbContext<User>(options)
    {
        
    }

    public class User : IdentityUser
    {
        public bool MemberGym { get; set; }
        public bool Gym { get; set; }
        public bool PersonalTrainer { get; set; }
        
        [MaxLength(14)]
        public string Document { get; set; } = string.Empty;
    }
}
