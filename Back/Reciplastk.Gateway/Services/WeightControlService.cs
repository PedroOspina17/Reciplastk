﻿using Azure;
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
        private Weightcontrol FindById(int id)
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

        public HttpResponseModel GetById(int id)
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

        public HttpResponseModel CreateSeparation(WeightControlViewModel model)
        {
            var response = new HttpResponseModel();

            var newWeightControl = new Weightcontrol();
            newWeightControl.Employeeid = model.Employeeid;
            newWeightControl.Weightcontroltypeid = 1; // To do: Change to config value.
            newWeightControl.Datestart = DateTime.Now;
            newWeightControl.Ispaid = false;
            newWeightControl.Creationdate = DateTime.Now;
            newWeightControl.Isactive = true;
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
        public HttpResponseModel CreateGrinding(GrindingViewModel model)
        {
            var response = new HttpResponseModel();
            var newWeightControl = new Weightcontrol();
            newWeightControl.Employeeid = 29; // To do: replace with confing value
            newWeightControl.Weightcontroltypeid = 2; // To do: replace with confing value
            newWeightControl.Datestart = DateTime.Now;
            newWeightControl.Ispaid = false;
            newWeightControl.Creationdate = DateTime.Now;
            newWeightControl.Isactive = true;
            db.Weightcontrols.Add(newWeightControl);

            var detail = new Weightcontroldetail();
            detail.Weightcontrol = newWeightControl;
            detail.Weight = model.PackageCount * 25; // To do: replace with confing value
            detail.Productid = model.ProductId;
            db.Weightcontroldetails.Add(detail);

            var remainig = new Remaining();
            remainig.Weightcontrol = newWeightControl;
            remainig.Productid = model.ProductId;
            remainig.Weight = model.Remainig;
            remainig.Creationdate = DateTime.Now;
            remainig.Isactive = true;
            db.Remainings.Add(remainig);

            db.SaveChanges();
            response.WasSuccessful = true;
            response.StatusMessage = "El dato fue agregado correctamente";
            return response;
        }
        public HttpResponseModel Update(WeightControlViewModel model)
        {
            var weightcontrol = FindById(model.Weightcontrolid ?? -1);
            var response = new HttpResponseModel();
            if (weightcontrol != null)
            {
                weightcontrol.Employeeid = model.Employeeid;
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
                response.StatusMessage = "El control de peso indicado no existe";
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

        public HttpResponseModel GetGroundProducts()
        {
            var response = new HttpResponseModel();
            var query = db.Weightcontroldetails
                .Where(w => w.Weightcontrol.Isactive && w.Weightcontrol.Weightcontroltypeid == 2 && w.Weightcontrol.Datestart > DateTime.Today && w.Weightcontrol.Datestart < DateTime.Today.AddDays(1))
                .Select(w => new GroundProductViewModel()
                {
                    detailId = w.Weightcontroldetailid,
                    controlId = w.Weightcontrolid,
                    Weight = w.Weight,
                    ProductName = w.Product.Name,
                    DateStart = w.Weightcontrol.Datestart,
                    Remaining = (w.Weightcontrol.Remainings.Count <= 0 ? 0 : w.Weightcontrol.Remainings.FirstOrDefault().Weight),
                })
            .OrderByDescending(w => w.detailId)
            .ToList();

            response.WasSuccessful = true;
            response.Data = query;
            return response;
        }
    }
}