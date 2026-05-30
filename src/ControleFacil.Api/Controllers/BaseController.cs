using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ControleFacil.Api.Contract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace ControleFacil.Api.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        protected long ObterIdUsuarioLogado()
        {
            var id = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            long.TryParse(id, out long idUsuario );
            
            return idUsuario;
        }

        protected ModelErrorContract RetornarModelBadRequest(Exception ex)
        {
            return new ModelErrorContract
                {
                    Status = 400,
                    Tittle = "Bad Request",
                    Message = ex.Message,
                    DateTime = DateTime.Now
                };
        }

        protected ModelErrorContract RetornarModelNotFound (Exception ex)
        {
            return new ModelErrorContract
                {
                    Status = 404,
                    Tittle = "Not Found",
                    Message = ex.Message,
                    DateTime = DateTime.Now
                };
        }

        protected ModelErrorContract RetornarModelUnauthorized (Exception ex)
        {
            return new ModelErrorContract
                {
                    Status = 401,
                    Tittle = "Unauthorized",
                    Message = ex.Message,
                    DateTime = DateTime.Now
                };
        }
    }
}