using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DentalisApp.Data
{
    public class DentalisAppDbContex : IdentityDbContext
    {
        public DentalisAppDbContex(DbContextOptions<DentalisAppDbContex> options) 
        : base(options)
        {

        }

       
    }
}
