using System.Collections.Generic;

namespace GetData2016.Models.XeHoi
{
    public class ChoTotCars
    {
        public int total { get; set; }
        public IList<ChoTotCar> ads { get; set; }
    }
    public class ChoTotCar
    {
        public string ad_id { get; set; }
        public string list_id { get; set; }
        public string list_time { get; set; }
        public string date { get; set; }
        public string account_id { get; set; }
        public string account_oid { get; set; }
        public string account_name { get; set; }
        public string subject { get; set; }
        public string category { get; set; }
        public string area { get; set; }
        public string area_name { get; set; }
        public string region { get; set; }
        public string region_name { get; set; }
        public string company_ad { get; set; }
        public string price { get; set; }
        public string price_string { get; set; }
        public string image { get; set; }
        public string number_of_images { get; set; }
        public string mfdate { get; set; }
        public string avatar { get; set; }

        //"ad_id": 48246403,
        //  "list_id": 31526447,
        //  "list_time": 1499054437473,
        //  "date": "hÃ´m nay 11:00",
        //  "account_id": 2598198,
        //  "account_oid": "dbab8fba3c90a5f24f097589b3829842",
        //  "account_name": "Phi",
        //  "subject": "xe isuzu Ä‘á»i 2009",
        //  "category": 2010,
        //  "area": 44,
        //  "area_name": "KhÃ¡nh HÃ²a",
        //  "region": 7,
        //  "region_name": "Nam Trung Bá»™",
        //  "company_ad": true,
        //  "type": "s",
        //  "price": 405000000,
        //  "price_string": "405.000.000 Ä‘",
        //  "image": "https://static.chotot.com.vn/mob_thumbs_app/04/0497225540.jpg",
        //  "number_of_images": 6,
        //  "mfdate": 2009,
        //  "avatar": "https://static.chotot.com.vn/imaginary/d20aea199fcca1e5d34ccafd7653803331648a16/profile_avatar/f2ca62a63e506634d9c7cbb6ff64476727136da8/thumbnail?width=32"
    }
}
