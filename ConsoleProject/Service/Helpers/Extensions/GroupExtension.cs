using Domain.Models;
using Respository.Data;
using Service.Services;
using Service.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Service.Helpers.Extensions
{
    public static class GroupExtension
    {
        public static bool RepetitionName(this string name)
        {
            return AppDbContext<Group>.Datas.Exists(n => n.Name == name);
        }

    }
}
