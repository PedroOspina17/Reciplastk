using Microsoft.EntityFrameworkCore;
using Reciplastk.Gateway.DataAccess;
using Reciplastk.Gateway.Models;

namespace Reciplastk.Gateway.Services
{
    public class WeightControlService
    {

        private readonly ReciplastkContext db;
        public WeightControlService(ReciplastkContext db)
        {
            this.db = db;
        }
        private Weightcontrol FindById(int? id)
        {
            var weightcontrol = db.Weightcontrols.Where(p => p.Isactive == true && p.Weightcontrolid == id).FirstOrDefault();
            return weightcontrol;

        }
        public HttpResponseModel GetAll()
        {
            var weightControl = db.Weightcontrols.Where(p => p.Isactive == true).ToList();
            var response = new HttpResponseModel();
            response.WasSuccessful = true;
            response.Data = weightControl;
            return response;
        }

        public HttpResponseModel GetById(int? id)
        {
            var weightcontrol = FindById(id);
            var response = new HttpResponseModel();
            if (weightcontrol != null)
            {
                response.WasSuccessful = true;
                response.Data = weightcontrol;
            }
            else
            {
                response.WasSuccessful = false;
                response.StatusMessage = "No se encontro el Registro con el id buscado";
            }
            return response;
        }

        public HttpResponseModel Create(WeightControlViewModel model)
        {
            var response = new HttpResponseModel();
           
            var newWeightControl = new Weightcontrol();
            newWeightControl.Employeeid = model.Employeeid;
            newWeightControl.Weightcontroltypeid = model.WeightControlTypeId;
            newWeightControl.Datestart = DateTime.Now;
            newWeightControl.Ispaid = false;
            newWeightControl.Creationdate = DateTime.Now;
            newWeightControl.Isactive = false;
            db.Weightcontrols.Add(newWeightControl);
            foreach (var i in model.weightdetail)
            {
                var detail = new Weightcontroldetail();
                detail.Weightcontrol = newWeightControl;
                detail.Productid = i.ProductId;
                detail.Weight = i.Weight;
                db.Weightcontroldetails.Add(detail);
            }
            db.SaveChanges();
            response.WasSuccessful = true;
            response.StatusMessage = "El dato fue agregado correctamente";

      
            return response;

        }
        public HttpResponseModel Update(WeightControlViewModel model)
        {
            var weightcontrol = FindById(model.Weightcontrolid);
            var response = new HttpResponseModel();
            if (weightcontrol != null)
            {
                weightcontrol.Employeeid = model.Employeeid;
                weightcontrol.Weightcontroltypeid = model.WeightControlTypeId;
                weightcontrol.Ispaid = false;
                weightcontrol.Updatedate = DateTime.Now;
                weightcontrol.Isactive = false;
                db.SaveChanges();
                response.WasSuccessful = true;
                response.Data = weightcontrol;
            }
            else
            {
                response.WasSuccessful = false;
                response.StatusMessage = "No pudo ser modificado";
            }
            return response;
        }

        public HttpResponseModel Delete(int id)
        {
            var weightcontrol = FindById(id);
            var response = new HttpResponseModel();
            if (weightcontrol == null)
            {
                response.WasSuccessful = false;
                response.StatusMessage = "El control de peso no pudo ser eliminado";
            }
            else
            {
                weightcontrol.Dateend = DateTime.Now;
                weightcontrol.Isactive = false;
                db.SaveChanges();
                response.WasSuccessful = true;
                response.Data = weightcontrol;
            }
            return response;
        }



    }
}