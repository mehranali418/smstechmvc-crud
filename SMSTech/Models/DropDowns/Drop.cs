using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMSTech.Models.DropDowns
{
    public class Drop
    {
        public List<tb_Gender> Gender
        {
            get
            {
                dbGenderConnection dbGender = new dbGenderConnection();
                return dbGender.tb_Gender.ToList();
            }
        }


        public List<tb_Class> Class
        {
            get
            {
                dbClassEntities dbClass = new dbClassEntities();
                return dbClass.tb_Class.ToList();
            }
        }

        public List<tb_Section> Section
        {
            get {
                dbSectionEntities dbSection = new dbSectionEntities();
                return dbSection.tb_Section.ToList();
               }
        }

        public List<tb_Religion> Religion
        {
            get
            {
                dbReligionEntities dbReligion = new dbReligionEntities();
                return dbReligion.tb_Religion.ToList();
            }
        }

        public List<tb_City> POB
        {
            get
            {
                dbPOBEntities dbPOB = new dbPOBEntities();
                return dbPOB.tb_City.ToList();
            }
        }

        public List<tb_stdHouse> StudentHouse
        {
            get
            {
                dbStudentHouseEntities dbHouse = new dbStudentHouseEntities();
                return dbHouse.tb_stdHouse.ToList();
            }
        }


        public List<tb_BGroup> BloodGroup
        {
            get
            {
                dbBloodGroupEntities dbBloodGroup = new dbBloodGroupEntities();
                return dbBloodGroup.tb_BGroup.ToList();
            }
        }

        public List<tb_City> City
        {
            get
            {
                dbCityEntities dbCity = new dbCityEntities();
                return dbCity.tb_City.ToList();
            }
        }
    }
}