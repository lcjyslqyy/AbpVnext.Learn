using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Values;
using Microsoft.EntityFrameworkCore;

namespace AbpVnext.Learn.Entitys
{
    public class User: AggregateRoot<Guid>
    {
        /// <summary>
        /// 用户名称
        /// </summary>
        [Required]
        [Column(TypeName ="varchar(50)")]
        public string user_name { get; set; }
        /// <summary>
        /// 用户手机号
        /// </summary>
        [Required]
        [Column(TypeName = "varchar(20)")]
        public string user_phone { get; set; }
        /// <summary>
        /// 登录密码
        /// </summary>
        [Required]
        [Column(TypeName ="varchar(50)")]
        public string pass_word { get; set; }
        /// <summary>
        /// 用户状态
        /// </summary>
        [Required]
        [Column(TypeName = "int")]
        public int user_status { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime create_time { get; set; }
        /// <summary>
        /// 授权id列表
        /// </summary>
        public List<UserAuthorizeList> UserAuthorizeLists { get; set; }
    }
    /// <summary>
    /// 授权列表，主要用于微信公从号，小程序之类的授权
    /// </summary>
    public class UserAuthorizeList:Entity
    {
        [Required]
        [Key]
        [Column(TypeName = "varchar(100)")]
        public Guid userid { get; set; }
        [Required]
        [Key]
        [Column(TypeName = "varchar(100)")]
        public string sourceid { get; set; }
        [Required]
        [Key]
        [Column(TypeName = "varchar(100)")]
        public string sourcetype { get; set; }
        [Required]
        [Column(TypeName = "varchar(500)")]
        public string value { get; set; }
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime createtime { get; set; }
        public override object[] GetKeys()
        {
            return new Object[] { userid, sourceid, sourcetype };
        }

    }
}
