using Domain.Models;
using Respository.Data;
using Service.Services;
using Service.Services.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            return AppDbContext<Group>.Datas.Exists(n => n.Name ==name.ToLower().Trim());
        }
        public static bool CheckGroup(this int groupId)
        {
            return AppDbContext<Student>.Datas.Exists(n => n.Id == groupId);
        }
    }
}
