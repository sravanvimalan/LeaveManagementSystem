using LeaveManagementSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeaveManagementSystem.Repository;
using AutoMapper;
using LeaveManagementSystem.DomainModel;
using System.Web.Mvc;

namespace LeaveManagementSystem.ServiceLayer
{
   
    public class GenderService : IGenderService
    {
        IGenderRepository genderrepo;

        public GenderService(IGenderRepository genderrepo)
        {
            this.genderrepo = genderrepo;
        }

        public List<Gender> GetAllGender()
        {
           
            //List <GenderViewModel> gvm = null;
            //var config = new MapperConfiguration(cfg =>
            //{
            //    cfg.CreateMap<Gender, GenderViewModel>();
            //});

            //IMapper mapper = config.CreateMapper();

            //gvm = mapper.Map<List<Gender>, List<GenderViewModel>>(g);

            return genderrepo.GetGenders();



        }

        public IEnumerable<SelectListItem> GenderList()
        {
            return GetSelectListItemsGender(genderrepo.GetGenders());
        }
        
     public IEnumerable<SelectListItem> GetSelectListItemsGender(IEnumerable<Gender> genders)
        {

            var selectList = new List<SelectListItem>();


            foreach (var item in genders)
            {
                selectList.Add(new SelectListItem
                {
                    Value = item.GenderID.ToString(),
                    Text = item.GenderName
                });
            }

            return selectList;
        }

        public string GetGenderById(int GenderId)
        {
            return genderrepo.GetGenderByID(GenderId);
        }
    }
}
