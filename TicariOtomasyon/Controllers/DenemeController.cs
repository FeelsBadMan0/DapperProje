using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.App;

namespace TicariOtomasyon.Controllers
{
    public class DenemeController : Controller
    {
        //[ValidateAntiForgeryToken]
        //[HttpPost]
        //public JsonResult Mesaileristele(Urunler urun, FormCollection form)
        //{
        //    string fquery = "";// Birince query değişkeni
        //    string fquery2 = ""; // İkinci query değişkeni

        //    // Filtreleme işlemleri
        //    var props = urun.GetType().GetProperties();//Ürünlerdeki değerlerin propertylerini alıyoruz.
        //    foreach (PropertyInfo prop in props) // ÜPropertyler içinde foreach ile dönüyoruz.
        //    {
        //        var ptype = prop.PropertyType.Name; //Property türünü alıyoruz
        //        var pname = prop.Name; //Property adınız alıyoruz.
        //        var pval = prop.GetValue(urun) != null ? app.ToSafeString(prop.GetValue(urun).ToString()) : null; //Propertylerin değerleri içerisinde ürünlerdeki değerleri arıyoruz. Eğer null değilse stringe çevirip geriye döndürüyoruz. Null ie null olarak devam ediyoruz.

        //        if (pname == "start" || pname == "length" || pname == "draw") //parametre değerleri start lentgh veya draw mı diye kontrolünü yapıyoruz.
        //        {
        //            continue; //Devam ediyoruz
        //        }
        //        else if (!String.IsNullOrEmpty(pval) && pval != "-1") //Property değeri null ve -1 değilse 
        //        {
        //            if (pname == "FIRMAKODU") //property adı FIRMAKODU ise giriyoruz.
        //            {
        //                fquery += " KULLANICIKODU IN (SELECT KAYITKODU FROM ISM_KULLANICILAR WHERE FIRMAKODU=@FIRMAKODU) AND "; // Birinci sorgumuza SQL sorgumuzu yazıyoruz. KULLANICIKODU içerisinde ISM_KULLANICILAR'daki FIRMAKODU gelen FIRMAKODU eşit olan KAYITKODUNU ve 
        //            }
        //            else fquery += " " + pname + " LIKE '%' + CAST( @" + pname + " AS VARCHAR(500)) + '%' AND "; // Eğer property adı FIRMAKODU değilse Cast ile varchar bir paraetre değerine çeviriyoruz.
        //        }
        //    }
        //    if (fquery != "") //Eğer birince query boş değilse 
        //    {
        //        fquery = fquery.Substring(0, fquery.Length - 4); // Birinci query değişekninin 0. indexinden başlayıp qery uzunluğunun sondan 4 değerini almayacak şekilde atama yapıyoruz.
        //        fquery = " AND " + fquery; // Birinci fquery değişkenine  AND + Birinci fquery değişkenini atıyoruz.
        //    }

        //    fquery2 = fquery; // Daha sonra Birinci fquery değişkenini İkinci fquery değişkenine atıyoruz.

        //    string order = ""; // string order değişkeni oluşturuyoruz
        //    //Sıralama İşlemleri
        //    if (form["order[0][column]"] != null)//Eğer kolon boş değilse.
        //    {
        //        var col = form["order[0][column]"];//Hangi kolon olduğunu buluyoruz
        //        var altust = form["order[0][dir]"]; //Datatable artan veya azalana göre değerleri aldığımız yer
        //        var colname = form["columns[" + col + "][name]"]; //Kolon adını alıyoruz
        //        if (!String.IsNullOrEmpty(colname))
        //        {
        //            foreach (var item in urun.GetType().GetProperties()) // modeldeki propery'lerin alanların listesini dön
        //            {
        //                if (item.Name == colname) // modelde olan bir alan ise sıralama sorgusuna ekle.
        //                    order = altust == "asc" ? " ORDER BY " + colname + " ASC" : " ORDER BY " + colname + " DESC"; //Kolonu artan veya azalan değere göre sıralıyoruz.
        //            }

        //        }
        //        else
        //        {
        //            order = " ORDER BY CURRENT_TIMESTAMP";// Eğer kolon adi boşsa anlık zamana gre sırala
        //        }
        //    }
        //    else
        //    {
        //        order = " ORDER BY CURRENT_TIMESTAMP"; // Eğer kolon boşsa alın zamana göre sırala
        //    }
        //    if (String.IsNullOrEmpty(order))
        //    {
        //        order = " ORDER BY CURRENT_TIMESTAMP"; // Eğer order değişkeni boşsa anlık zaman göre sırala
        //    }
        //    fquery += order; // fquery değişkeninin üzerine ekle

        //    //Sayfalama işlemleri
        //    if (urun.length > 0)
        //    {
        //        fquery += " OFFSET " + urun.start + " ROWS FETCH NEXT " + urun + " ROWS ONLY"; //OFFSET, sorgudan satır döndürmeye başlamadan önce atlanacak satır sayısını belirtir.
        //        //Ürünün başlangıcını urun.start ROWS olarak alıyoruz ve FETCH NEXT ile döndürüleeck satır sayısını belirtir.
        //    }

        //    var stkData = new object();
        //    int stkCount = 0;

        //    stkData = usrrep.getIsmKullanicilarDetayMesaiList(fquery, urun);
        //    stkCount = usrrep.getIsmKullanicilarDetayMesaiListCount(fquery2, urun);


        //    return Json(new
        //    {
        //        aaData = stkData,
        //        draw = urun.draw,
        //        recordsTotal = stkCount,
        //        recordsFiltered = stkCount,
        //    }, JsonRequestBehavior.AllowGet);
        //}
    }
}
       

    
