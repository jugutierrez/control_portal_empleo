using control_portal_empleo.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace control_portal_empleo.Controllers
{
    public class loginController : Controller
    {
        //
        // GET: /login/
        PersonaDBContext db = new PersonaDBContext();
        // GET: /Login/
        public ActionResult Index(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
  
                    return View();
  
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(usuarios model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = checkUser(model.rut_usuario, model.clave_usuario);
                if (user != null)
                {
                    var vSessionValue = new usuarios();
                    Control_modulos c_m = new Control_modulos();
                    SignInAsync(user.id_usuario);
                    Session["usuario_id"] = user.id_usuario;
                    Session["role_id"] = user.id_tipo_usuario;
                    // Session["curriculum_id"] = user.id_curriculum;
                    vSessionValue.id_usuario = Convert.ToInt32(Session["usuario_id"]);
                    vSessionValue.id_tipo_usuario = Convert.ToInt32(Session["role_id"]);
                    //vSessionValue.id_curriculum = Convert.ToInt32(Session["curriculum_id"]);
                    Session["modulos"] = c_m.validador_modulos(Convert.ToInt32(Session["role_id"]));

                    //double[] arr = (double)(Session["your_array"]);
                    return RedirectToAction("index", "ofertas_main");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password.");
                }
            }
            return View(model);
        }

        private void SignInAsync(int id2)
        {


            var k = db.usuarios.Find(id2);
            var claims = new List<Claim>
            {
          new Claim(ClaimTypes.Name, k.nombre_usuario),
           new Claim(ClaimTypes.Role, k.id_tipo_usuario.ToString())
                 };
            var id = new ClaimsIdentity(claims,
                                        DefaultAuthenticationTypes.ApplicationCookie);

            var ctx = Request.GetOwinContext();
            var authenticationManager = ctx.Authentication;
            authenticationManager.SignIn(id);





            // check existing value into session


        }


        public ActionResult registro()
        {

            ViewBag.id_departamento = new SelectList(db.departamentos, "id_departamento", "nombre_departamento");


            ViewBag.id_area = new SelectList(db.areas, "id_area", "nombre_area");
            ViewBag.id_direccion = new SelectList(db.direcciones, "id_direccion", "nombre_direccion");
            ViewBag.id_tipo_usuario = new SelectList(db.tipo_usuarios, "id_tipo_usuario", "nombre_tipo_usuario");

            return View();
        }
        public static usuarios checkUser(string userName, string password)
        {
            PersonaDBContext db = new PersonaDBContext();

            var query = (from u in db.usuarios
                         where u.nombre_cuenta_usuario == userName && u.clave_usuario == password && u.id_estado_usuario != 0
                         select u).FirstOrDefault();
            if (query != null)
                return query;
            else
                return null;
        }


     
        [Authorize]
        public ActionResult LogOff()
        {

           
     
            
            AuthenticationManager.SignOut();
            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();

            return RedirectToAction("Index", "login");
        }


        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult create_registro([Bind(Include = "nombre_usuario ,apellido_paterno_usuario , apellido_materno_usuario , rut_usuario ," +
           " clave_usuario , id_area  ,id_tipo_usuario  id_estado_usuario ,dig_rut_usuario ,anexo_usuario ,correo_electronico_usuario  , nombre_cuenta_usuario")] usuarios usuarios)
        {


            if (ModelState.IsValid)
            {
                usuarios.id_estado_usuario = 0;
                usuarios.fecha_creacion_usuario = DateTime.UtcNow.Date;
                usuarios.fecha_actualizacion_usuario = DateTime.UtcNow.Date;
                db.usuarios.Add(usuarios);
                db.SaveChanges();
                /*
                 
            
              
               
       
                db.Database.ExecuteSqlCommand("Exec sp_inserta_persona_curriculum @nombre_persona = {0} , @apellido_paterno_persona = {1} , @apellido_materno_persona = {2}, @identificacion_persona = {3}, @correo_electronico_persona = {4} , @fecha_nacimiento_persona = {5} , @clave_persona = {6} , @id_comuna = {7} , @id_tipo_identificacion_persona = {8} , @id_discapacidad_persona = {9} , @id_tipo_persona = {10} , @direccion_curriculum  = {11} , @telefono_curriculum_1 = {12} , @telefono_curriculum_2 = {13} ", persona_curriculum_vista.nombre_persona, persona_curriculum_vista.apellido_paterno_persona, persona_curriculum_vista.apellido_materno_persona, persona_curriculum_vista.identificacion_persona, persona_curriculum_vista.correo_electronico_persona, persona_curriculum_vista.fecha_nacimiento_persona, persona_curriculum_vista.clave_persona, persona_curriculum_vista.id_comuna, persona_curriculum_vista.id_tipo_identificacion_persona, persona_curriculum_vista.id_discapacidad_persona, persona_curriculum_vista.id_tipo_persona, persona_curriculum_vista.direccion_curriculum, persona_curriculum_vista.telefono_curriculum_1, persona_curriculum_vista.telefono_curriculum_2);
                 * */
                return Json(new { success = true, responseText = "Your message successfuly sent!" }, JsonRequestBehavior.AllowGet);
            }



            return Json(new { success = false, responseText = "error plox" }, JsonRequestBehavior.AllowGet);


        }
        public JsonResult GetCountries()
        {
            return Json(db.direcciones.ToList(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetStatesByCountryId(string countryId)
        {
            try
            {
                int Id = Convert.ToInt32(countryId);


                // var states = from a in db.departamentos where a.id_direccion == Id select a;
                List<departamentos> results = db.Database.SqlQuery<departamentos>("Exec sp_obtener_departamentos @id_direccion = {0}  ", Id).ToList();
                return Json(results, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult GetStatesByCountryId2(string countryId)
        {
            try
            {
                int Id = Convert.ToInt32(countryId);


                //var states = from a in db.ciudades where a.id_region == Id select a;
                List<areas> results2 = db.Database.SqlQuery<areas>("Exec sp_obtener_areas @id_departamentos = {0}  ", Id).ToList();
                return Json(results2, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }






        public ActionResult pie()
        {
            return View();
        }

        public JsonResult pie2()
        {


            var chartsdata = db.tipo_ofertas.ToList();


            return Json(chartsdata, JsonRequestBehavior.AllowGet);
        }

        public PartialViewResult recordar_credenciales()
        {
            return PartialView("_recordar_login");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult recordar_login(FormCollection form)
        {
            mail m = new mail();
            try
            {
                string[] rad = new string[form.AllKeys.Count()];
            if (form.AllKeys.Length != 0)
            {
                for (int i = 0; i < form.AllKeys.Count(); i++)
                {
                    if (Request[form.Keys[i]] != "")
                    {
                        rad[i] = Request[form.Keys[i]];
                    }
                    else
                    {

                            return Json(new { success = false, responseText = "Campo por completar : "+ form.Keys[i].ToString() }, JsonRequestBehavior.AllowGet);
                        }

                }

            }

            

      
            
                m.enviar_correo(null, rad[5], 2);
                return Json(new { success = true, responseText = "Correo Enviado exitosamente , en breve un encargado se pondra en contacto." }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, responseText = " ha sucedido un error , favor intente nuevamente" }, JsonRequestBehavior.AllowGet);
            }
        }


    

    }
}