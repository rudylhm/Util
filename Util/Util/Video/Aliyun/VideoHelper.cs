using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util.Video.Aliyun
{
    public class VideoHelper
    {
        /// <summary>
        /// API调用地址
        /// </summary>
        private static string ApiUrl = "https://vod.cn-shanghai.aliyuncs.com/";

        private string AccessKeyId;

        private string AccessSecret;

        public VideoHelper(string accessKeyId, string accessSecret)
        {
            this.AccessKeyId = accessKeyId;
            this.AccessSecret = accessSecret;
        }

        public CallResult.VideoUrlResult GetVideoUrl(string videoID)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict["Action"] = "GetPlayInfo";
            dict["VideoId"] = videoID;
            dict["Formats"] = "mp4";
            dict = Common.MakeDict(dict, AccessKeyId);
            string sign = Common.MakeSign(dict, this.AccessSecret, "GET");
            dict["Signature"] = sign;
            string result = Util.Http.HttpDataUtil.GetWebData(ApiUrl, Util.StringCommon.StringHelper.DictToString(dict, "=", "&", false, null, false, true));
            return Util.Serialization.SimpleSerialization.JsonToObject<CallResult.VideoUrlResult>(result);
        }
    }
}
