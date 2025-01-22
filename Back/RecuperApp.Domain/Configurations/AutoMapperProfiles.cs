using AutoMapper;
using RecuperApp.Domain.Models.EntityModels;
using RecuperApp.Domain.Models.ViewModels;

namespace RecuperApp.Domain.Configurations
{
    //Un perfil(Profile) en AutoMapper describe cómo la herramienta debe mapear un objeto de un tipo a otro.
    public class AutoMapperProfiles : Profile
    {
        //Automapper es una biblioteca versátil y potente en C# diseñada para facilitar el mapeo objeto a objeto, haciendo que la transferencia de datos entre modelos de objetos complejos sea más sencilla y fácil de mantener. En este artículo, exploraremos cómo Automapper puede asignar propiedades de forma eficiente, aplanar modelos de objetos complejos y trabajar con varios tipos de objetos como objetos de dominio de usuario y objetos de transferencia de datos.
        public AutoMapperProfiles()
        {
            CreateMap<EmployeeViewModel, Employee>(); // ToDo: Analyze the revese mapping.
            //CreateMap<EmployeeViewModel, Employee>().ReverseMap(); // ToDo: Analyze the revese mapping instead of two different maps.
            CreateMap<Employee, EmployeeViewModel>();
            CreateMap<RoleViewModel, Role>();
        }
    }
}
