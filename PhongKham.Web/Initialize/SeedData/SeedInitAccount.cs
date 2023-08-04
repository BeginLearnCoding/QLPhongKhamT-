using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using PhongKham.Core.Entities;
using PhongKham.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhongKham.Web.Initialize.SeedData
{
    public class SeedInitAccount
    {
        private readonly UserManager<UserAccount> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public SeedInitAccount(
            UserManager<UserAccount> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task SeedAsync()
        {
            var AdminRole = new IdentityRole
            {

                Name = "Admin",
                NormalizedName = "AMDIN"
            };
            var BacSiRole = new IdentityRole
            {

                Name = "BacSi",
                NormalizedName = "BACSI"
            };
            var NhanVienRole = new IdentityRole
            {

                Name = "NhanVien",
                NormalizedName = "AMDIN"
            };
            await CreateRoleAsync(AdminRole);
            await CreateRoleAsync(BacSiRole);
            await CreateRoleAsync(NhanVienRole);

            var Password = "P@ssword1";

            var AdminUser = new UserAccount
            {
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@cnpm.com",
                NormalizedEmail = "ADMIN@CNPM.COM",
                EmailConfirmed = true,
            };
            var BacSiUser = new UserAccount
            {
                UserName = "bacsi",
                NormalizedUserName = "BACSI",
                Email = "bacsi@cnpm.com",
                NormalizedEmail = "BACSI@CNPM.COM",
                EmailConfirmed = true,
            };
            var NhanVienUser = new UserAccount
            {
                UserName = "nhanVien",
                NormalizedUserName = "NHANVIEN",
                Email = "nhanvien@cnpm.com",
                NormalizedEmail = "ADMIN@CNPM.COM",
                EmailConfirmed = true,
            };
            await CreateUserAsync(AdminUser, Password);
            await CreateUserAsync(BacSiUser, Password);
            await CreateUserAsync(NhanVienUser, Password);

            var AdminInRole = await _userManager.IsInRoleAsync(AdminUser, AdminRole.Name);
            if (!AdminInRole)
                await _userManager.AddToRoleAsync(AdminUser, AdminRole.Name);
            var BSInRole = await _userManager.IsInRoleAsync(BacSiUser, BacSiRole.Name);
            if (!BSInRole)
                await _userManager.AddToRoleAsync(BacSiUser, BacSiRole.Name);
            var NVInRole = await _userManager.IsInRoleAsync(NhanVienUser, NhanVienRole.Name);
            if (!NVInRole)
                await _userManager.AddToRoleAsync(NhanVienUser, NhanVienRole.Name);
        }

        private async Task CreateRoleAsync(IdentityRole role)
        {
            var exits = await _roleManager.RoleExistsAsync(role.Name);
            if (!exits)
                await _roleManager.CreateAsync(role);
        }

        private async Task CreateUserAsync(UserAccount user, string password)
        {
            var exists = await _userManager.FindByEmailAsync(user.Email);
            if (exists == null)
                await _userManager.CreateAsync(user, password);
        }


    }
}
