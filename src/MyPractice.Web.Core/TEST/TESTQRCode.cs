using Microsoft.AspNetCore.Mvc;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using Abp.Dependency;
using System.IO;
using MyPractice.Controllers;

namespace MyPractice.TEST
{

    [Route("api/[controller]/[action]")]
    public class TESTQRCode: MyPracticeControllerBase, ITransientDependency
    {
        /// <summary>
        /// 生成二维码
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult MakeQrCode(string str)
        {

            //string url = "https://www.baidu.com";

            var generator = new QRCodeGenerator();

            var codeData = generator.CreateQrCode(str, QRCodeGenerator.ECCLevel.M, true);

            QRCoder.QRCode qrcode = new QRCoder.QRCode(codeData);
            var qrImage = qrcode.GetGraphic(10, Color.Black, Color.White, true);
            var ms = new MemoryStream();

            //图片格式指定为png
            qrImage.Save(ms, ImageFormat.Jpeg);

            byte[] bytes = ms.GetBuffer();
            ms.Close();
            return File(bytes, "image/Png");
        }
    }
}
