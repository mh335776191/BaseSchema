﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Duanzu.House.DataContract.HouseModel.BusinessModel;

namespace Duanzu.FD.Controller.Controllers
{
    public class LandLordController : Duanzu.Controller.Controllers.BaseController
    {
        /// <summary>
        /// 默认未登录返回登录页
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
           if (!IsLogin)
            {
                //请登录 
               // filterContext.Result = new RedirectResult(TXCommons.BasicsClass.PubConstant.KyjBaseUrl + "register/newlogin?url=" + TXCommons.BasicsClass.ForKuaiYouJiaCookie.BaseRC4.RC4Encrypt(TXCommons.BasicsClass.PubConstant.DuanzuBaseUrl + "DuanzuFD/LandLord/MyDuanzuHouseList"));
                ContentResult js = new ContentResult();
                js.Content = "<script type=\"text/javascript\">alert('你还未登录！');window.location.href='" + TXCommons.BasicsClass.PubConstant.KyjBaseUrl + "register/newlogin'</script>";
                filterContext.Result = js;
                base.OnActionExecuting(filterContext);
            } 
        }

        /// <summary>
        /// 用户中心公告head
        /// </summary>
        /// <returns></returns>
        public ActionResult PublicHead()
        {

            return View();
        }

        #region 房东-房源管理列表
        /// <summary>
        /// 房东-房源管理列表
        /// </summary>
        /// <returns></returns>
        public ActionResult MyDuanzuHouseList()
        {
<<<<<<< .mine
            //List<DuanzuHouseInfo> list =new List<DuanzuHouseInfo>();
            //DuanzuHouseInfo model = new DuanzuHouseInfo();
=======
            List<FavoriteHouseInfo> list = new List<FavoriteHouseInfo>();
            FavoriteHouseInfo model = new FavoriteHouseInfo();
>>>>>>> .r13528

            //model.HouseID = 1;
            //model.HousePhoto = "";
            //model.AuditState = 1;
            //model.Balcony = 1;
            //model.Hall = 1;
            //model.HouseType = 1;
            //model.RentPrice = 300;
            //model.Room = 1;
            //model.Status = 1;
            //model.Title = "sdfsdf";
            //model.Toilet = 1;
            //model.UserID = 405;
            //model.PeopleNumber = 3;
            //model.PayStatus = 1;
            //model.PayAmount = 300;
            //model.CreateTime = DateTime.Now;
            //model.CityID = 253;
            //model.Balcony = 1;
            //model.RentType = 1;
            model.OrderStatus = 1;
            
            //list.Add(model);

            //ViewBag.Houselist = list;
            return View();
        }

        /// <summary>
        /// 房东-房源管理-查看订单
        /// note：列表排序“待入住”状态订单优先级最高，其他状态以入住时间倒序
        /// </summary>
        /// <returns></returns>
        public ActionResult DuanzuHouseOrderList(int houseId)
        {
            //当前user
            int uid = GetUserId;
            //分页，每页10条
            int pageIndex = 1, pageSize = 10;
            int.TryParse(Request.QueryString["pn"], out pageIndex);
            pageIndex = pageIndex == 0 ? 1 : pageIndex;
            //总条数，总页数
            int totalRecord = 0;
            int totalPage = 3;

            List<DuanzuHouseOrderInfo> list = new List<DuanzuHouseOrderInfo>();
            DuanzuHouseOrderInfo model = new DuanzuHouseOrderInfo();

            model.Amount = 100;
            model.CreateTime = DateTime.Now;
            model.HouseID = 111;
            model.UserID = 405;
            model.RentStartDate = DateTime.Now;
            model.RentEndDate = DateTime.Now.AddDays(3);
            model.Mobile = "18612595027";
            model.OrderNum = "11";
            model.OrderStatus = 2;
            model.PeopleNumber = 3;
            model.ServiceCharge = 20;
            model.ToushuCount = 1;

            list.Add(model);

            if (list != null && list.Count>0)
            {
                foreach (var item in list)
                {
                    item.OrderStatusName = GetOrderStateName(item.OrderStatus);
                }
            }

            ViewBag.OrderList = list;
            ViewBag.totalPage = totalPage;
            ViewBag.totalRecord = totalRecord;
            ViewBag.pageIndex = pageIndex;
            ViewBag.houseId = houseId;

            return View();
        }

        /// <summary>
        /// 房东-房源管理-查看订单-投诉处理
        /// Note：显示租客提交的投诉信息
        /// </summary>
        /// <param name="hid"></param>
        /// <param name="orderNum"></param>
        /// <param name="orderState"></param>
        /// <returns></returns>
        public ActionResult ShowComplaintInfo(int hid, string orderNum, int orderState)
        {
            HouseComplaintInfo model = new HouseComplaintInfo();

            model.Amount = 300;
            model.Day = 2;
            model.TotalDay = 3;
            model.HouseId = 111;
            model.Id = 222;

            ViewBag.ComplaintInfo = model;
            ViewBag.orderNum = orderNum;
            ViewBag.orderState = orderState;
            ViewBag.TotalAmount = model.Amount * model.Day;

            return View();
        }

        /// <summary>
        /// 获取订单状态名
        /// </summary>
        /// <param name="orderStatus">订单状态标识</param>
        /// <returns></returns>
        public static string GetOrderStateName(int orderStatus)
        {
            string orderStateName = "";
            switch (orderStatus)
            { 
                case 0:
                    orderStateName = "待支付";
                    break;
                case 1:
                    orderStateName = "已支付";
                    break;
                case 2:
                    orderStateName = "待入住";
                    break;
                case 3:
                    orderStateName = "入住中";
                    break;
                case 4:
                    orderStateName = "待评价";
                    break;
                case 5:
                    orderStateName = "已完成";
                    break;
                case 6:
                    orderStateName = "已取消";
                    break;
                case 7:
                    orderStateName = "入住中";
                    break;
                case 8:
                    orderStateName = "投诉待处理";
                    break;
                case 9:
                    orderStateName = "已取消";
                    break;
            }
            return orderStateName;
        }
        #endregion

        #region 权威认证
        /// <summary>
        /// 权威认证 提交
        /// </summary>
        /// <returns></returns>
        public ActionResult FDAuthentication()
        {
            ViewBag.guid = Guid.NewGuid().ToString();

            int sfz = 0;
            int yyzz = 0;
            int zgzs = 0;

            //判断用户是否有已经审核通过的认证
            if (sfz > 0 || yyzz > 0 || zgzs > 0)
            {
                return Redirect("//DuanzuFD/LandLord/ShowSuccessFDAuthentication");
            }

            return View();
        }

        /// <summary>
        /// 权威认证成功提示页
        /// </summary>
        /// <returns></returns>
        public ActionResult ShowSuccessFDAuthentication()
        {
            int sfz = 0;
            int yyzz = 0;
            int zgzs = 0;
            //获取用户是否有待审核的身份认证
            int auitState = 0;
      
            ViewBag.sfz = sfz;
            ViewBag.yyzz = yyzz;
            ViewBag.zgzs = zgzs;
            ViewBag.auitState = auitState;

            return View();
        }
        #endregion
    }
}
