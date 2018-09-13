using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace WebApplication4.Controllers
{
    public class tblComapnyDetailsController : ApiController
    {
        private DBContext db = new DBContext();

        // GET: api/tblComapnyDetails
        public IQueryable<tblCompanyDetail> GettblComapnyDetails()
        {
            return db.tblCompanyDetails;
        }

        // GET: api/tblComapnyDetails/5
        [ResponseType(typeof(tblCompanyDetail))]
        public IHttpActionResult GettblComapnyDetail(int id)
        {
            tblCompanyDetail tblComapnyDetail = db.tblCompanyDetails.Find(id);
            if (tblComapnyDetail == null)
            {
                return NotFound();
            }

            return Ok(tblComapnyDetail);
        }

        // PUT: api/tblComapnyDetails/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblComapnyDetail(int id, tblCompanyDetail tblComapnyDetail)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            if (id != tblComapnyDetail.CompanyID)
            {
                return BadRequest();
            }

            db.Entry(tblComapnyDetail).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblComapnyDetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/tblComapnyDetails
        [ResponseType(typeof(tblCompanyDetail))]
        public IHttpActionResult PosttblComapnyDetail(tblCompanyDetail tblComapnyDetail1)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            try { 
            db.tblCompanyDetails.Add(tblComapnyDetail1);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tblComapnyDetail1.CompanyID }, tblComapnyDetail1);
            }
           catch (System.Data.Entity.Validation.DbEntityValidationException err) { throw err; }
            }

        // DELETE: api/tblComapnyDetails/5
        [ResponseType(typeof(tblCompanyDetail))]
        public IHttpActionResult DeletetblComapnyDetail(int id)
        {
            tblCompanyDetail tblComapnyDetail = db.tblCompanyDetails.Find(id);
            if (tblComapnyDetail == null)
            {
                return NotFound();
            }

            db.tblCompanyDetails.Remove(tblComapnyDetail);
            db.SaveChanges();

            return Ok(tblComapnyDetail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblComapnyDetailExists(int id)
        {
            return db.tblCompanyDetails.Count(e => e.CompanyID == id) > 0;
        }
    }
}