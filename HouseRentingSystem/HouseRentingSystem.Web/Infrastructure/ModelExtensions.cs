using HouseRentingSystem.Services.Houses.Models;
using System.Text.RegularExpressions;

namespace HouseRentingSystem.Web.Infrastructure
{
    public static class ModelExtensions
    {
        public static string GetInformation(this IHouseModel house)
            => house.Title.Replace(" ", "-") + "-" + GetAddress(house.Address);

        private static string GetAddress(string address)
        {
            address = string.Join("-", address.Split(" ").Take(3));
            return Regex.Replace(address, @"[^a-zA-Z0-9\-]", string.Empty);
        }
    }
}
