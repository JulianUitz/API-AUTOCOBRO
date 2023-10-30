using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using nuevapicobro.Domain.Entities;
using nuevapicobro.Services.Features;

namespace nuevapicobro.Controllers.V1
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
         private readonly IUsuarioService _usuarioService;

    public UserController(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Usuario>> GetUsuarios()
    {
        var usuarios = _usuarioService.GetAllUsuarios();
        // Devolver respuesta adecuada
        return Ok(usuarios);
    }

   
}
}