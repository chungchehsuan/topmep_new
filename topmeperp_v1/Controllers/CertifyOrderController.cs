using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using log4net;
using topmeperp.Models;
using topmeperp.Service;

namespace topmeperp.Controllers
{
    public class CertifyOrderController : Controller
    //Server = new Service();
    {
        static ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        // GET: CerifyOrder
        public ActionResult Index()
        {
            //List<topmeperp.Models.PLAN_SUP_INQUIRY> lst = new List<PLAN_SUP_INQUIRY>();
            List<topmeperp.Models.PLAN_CERT_ORDER> lst = new List<PLAN_CERT_ORDER>();
            var projectID = Request.Url.ToString().Split('/').Last();
            using (var context = new topmepEntities())
            {
                /*var query = from s in context.PLAN_CERT_ORDER
                            where s.PROJECT_ID == projectID
                            select s;
                lst = query.ToList();*/
                lst = context.PLAN_CERT_ORDER.SqlQuery("SELECT * FROM PLAN_CERT_ORDER WHERE PLAN_CERT_ORDER.PROJECT_ID = '"+projectID + "'").ToList();

            }
            ViewBag.projectId = projectID;
            ViewBag.lst = lst;
            return View();
        }

        public ActionResult Create()
        {

            List<topmeperp.Models.PLAN_SUP_INQUIRY> lst = new List<PLAN_SUP_INQUIRY>();
            var prjID = Request.Url.ToString().Split('/').Last();
            using (var context = new topmepEntities())
            {
                lst = context.PLAN_SUP_INQUIRY.SqlQuery("SELECT * FROM PLAN_SUP_INQUIRY" +
                    " Join PLAN_ITEM2_SUP_INQUIRY On PLAN_SUP_INQUIRY.INQUIRY_FORM_ID = PLAN_ITEM2_SUP_INQUIRY.INQUIRY_FORM_ID " +
                    "WHERE PLAN_SUP_INQUIRY.PROJECT_ID = '" + prjID + "'").ToList();
                //lst = query.ToList();

            }

            ViewBag.projectId = prjID;
            ViewBag.lst = lst;
            ViewBag.dict = new Dictionary<string, string>() {
                {"Y", "工資"},
                {"N", "材料/設備" },
                {"NULL", "材料/設備" }
            };
            return View();
        }

        public ActionResult AddItem()
        {

            List<topmeperp.Models.PLAN_SUP_INQUIRY_ITEM> lst = new List<PLAN_SUP_INQUIRY_ITEM>();
            var formID = Request.Url.ToString().Split('/').Last();
            using (var context = new topmepEntities())
            {
                lst = context.PLAN_SUP_INQUIRY_ITEM.SqlQuery("SELECT * FROM PLAN_SUP_INQUIRY_ITEM " +
                    "WHERE PLAN_SUP_INQUIRY_ITEM.INQUIRY_FORM_ID = '" + formID + "'").ToList();
                //lst = query.ToList();

            }

            ViewBag.projectId = formID;
            ViewBag.lst = lst;
            return View();
        }

        [HttpPost]
        public string AddItem(FormCollection f)
        {
            var inquiry = new topmeperp.Models.PLAN_SUP_INQUIRY();
            var formID = Request["formID"];
            var order = new topmeperp.Models.PLAN_CERT_ORDER();

            SerialKeyService snoservice = new SerialKeyService();
            string ordKey = snoservice.getSerialKey("EST");

            using (var context = new topmepEntities())
            {
                string sql;
                inquiry = context.PLAN_SUP_INQUIRY.SqlQuery("SELECT * FROM PLAN_SUP_INQUIRY WHERE INQUIRY_FORM_ID = '"+formID+"'").ToList().First();
                sql = "INSERT INTO PLAN_CERT_ORDER (CERT_ORD_ID,INQUIRY_FORM_ID,SUPPLIER_ID,PROJECT_ID) " +
                    "VALUES('"+ordKey+"','" + inquiry.INQUIRY_FORM_ID + "','" + inquiry.SUPPLIER_ID + "','" + inquiry.PROJECT_ID + "')";
                try
                {
                        
                        //order.CERT_ORD_ID = "test";
                        //order.INQUIRY_FORM_ID = inquiry.INQUIRY_FORM_ID.ToString();
                        //order.SUPPLIER_ID = inquiry.SUPPLIER_ID.ToString();
                        //order.PROJECT_ID = inquiry.PROJECT_ID.ToString();
                        //context.PLAN_CERT_ORDER.Add(order);
                        context.Database.ExecuteSqlCommand(sql);
                        context.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.Write(e.StackTrace);
                }

                var qty = Request["qty"];
                var plan_item_id = Request["plan_item_id"];
                var type = Request["type"];
                var subType = Request["subType"];
                var itemID = Request["itemID"];
                var desc = Request["desc"];

                int[] nums = Array.ConvertAll(qty.Split(','), int.Parse);
                string[] plan_item_ids = plan_item_id.Split(',');
                string[] types = type.Split(',');
                string[] subTypes = subType.Split(',');
                string[] itemIDs = itemID.Split(',');
                string[] descs = desc.Split(',');

                //var test = new PLAN_CERT_ORDER_ITEM { CERT_ORD_ITEM_ID = generate_id(), ORDER_QTY = nums[0] };
                var test2 = new PLAN_CERT_ORDER_ITEM { CERT_ORD_ITEM_ID = generate_id(),ORDER_QTY = nums[1] };

                //string sql = "INSERT INTO PLAN_CERT_ORDER_ITEM (CERT_ORD_ITEM_ID,ORDER_QTY) VALUES(28," + "10" + ")";
                try
                {
                    for (int i = 0; i < nums.Length; i++)
                    {
                        context.PLAN_CERT_ORDER_ITEM.Add(new PLAN_CERT_ORDER_ITEM
                        {
                            CERT_ORD_ITEM_ID = generate_id(),
                            CERT_ORD_ID = ordKey,
                            TYPE_CODE = types[i],
                            SUB_TYPE_CODE = subTypes[i],
                            ITEM_ID = itemIDs[i],
                            ITEM_DESC = descs[i],
                            ORDER_QTY = nums[i],
                            PLAN_ITEM_ID = plan_item_ids[i]
                        });
                    }
                    //context.PLAN_CERT_ORDER_ITEM.Add(test2);
                    //var x=0;
                    //context.Database.ExecuteSqlCommand(sql);
                    context.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.Write(e.StackTrace);
                }



                //generate random 64 int ID
                long testID = generate_id();

                string orderinfo = "{CERT_OrderID: " + order.CERT_ORD_ID + " FormID: " + inquiry.INQUIRY_FORM_ID + " Supplier: " + inquiry.SUPPLIER_ID + " ProjID: " + inquiry.PROJECT_ID;
                return "Item added in " + formID + "\n" + nums[0] + ", " + nums[1] + sql+"\n("+testID+":"+ordKey+")"+plan_item_ids[0];
            }
        }

        public long generate_id() {
            //generate random 64 int ID
            byte[] gb = Guid.NewGuid().ToByteArray();
            long id = BitConverter.ToInt64(gb, 0);
            return id;
        }
    }
}
