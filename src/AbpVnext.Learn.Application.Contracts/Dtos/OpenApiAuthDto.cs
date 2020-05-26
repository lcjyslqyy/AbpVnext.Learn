using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AbpVnext.Learn.Dtos
{
    /// <summary>
    /// 对外授权的接口模型
    /// </summary>
    public class OpenApiAuthDto
    {
        [Required]
        public string appid { get; set; }
        [Required]
        public string appsecret { get; set; }
    }
}
