using ClubIS.CoreLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClubIS.Web.Services.Implementations
{
    public class Searching
    {
        public static IEnumerable<int> SearchItems(IEnumerable<UserListDTO> users, string searchValue)
        {
            if (string.IsNullOrEmpty(searchValue))
            {
                return users.Select(u => u.Id);
            }

            return users.Where(u => $"{u.Surname} ({u.Firstname})".Contains(searchValue, StringComparison.InvariantCultureIgnoreCase)).Select(u => u.Id);
        }

        public bool FilterFunc(string searchData, string searchValue)
        {
            if (string.IsNullOrWhiteSpace(searchValue))
            {
                return true;
            }

            return searchData.Contains(searchValue, StringComparison.OrdinalIgnoreCase);
        }
    }
}
