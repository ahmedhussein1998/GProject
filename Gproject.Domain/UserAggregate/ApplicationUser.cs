using Gproject.Domain.Common.Models;
using Gproject.Domain.Common.ValueObjects;
using Microsoft.AspNetCore.Identity;

namespace Gproject.Domain.UserAggregate
{
    public sealed class ApplicationUser : IdentityUser, IAggregateRoot 
    {

        public FullName FullName { get; set; }
        public CellPhone Phone { get;  set; }
        public KeyValueLocalized Gender { get; set; }

        public KeyValueLocalized Nationality { get; set; }

        public string PictureFileName { get;  set; }




        public ApplicationUser(string email, FullName fullName, CellPhone phone,
             KeyValueLocalized gender, KeyValueLocalized nationality, string pictureFileName) 
        {
            Email = email;
            FullName = fullName;
            Phone = phone;
            Gender = gender;
            Nationality = nationality;
            PictureFileName = pictureFileName;


          
        }
#pragma warning disable CS8618
        public ApplicationUser() : base()
        {


        }

        #region Behavior
        public static ApplicationUser Create(string email, FullName fullName, CellPhone phone,
             KeyValueLocalized gender, KeyValueLocalized nationality, string pictureFileName)
        {
            return new(email,fullName, phone, gender, nationality , pictureFileName);
        }
        #endregion

#pragma warning restore CS8618
    }
}
