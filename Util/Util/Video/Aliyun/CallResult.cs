using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util.Video.Aliyun
{
    /// <summary>
    /// 调用阿里云接口后返回的结果
    /// </summary>
    public class CallResult
    {
        /// <summary>
        /// 视频流信息
        /// </summary>
        public class PlayInfoItem
        {
            /// <summary>
            /// 视频流码率，单位Kbps
            /// </summary>
            public string Bitrate { get; set; }

            /// <summary>
            /// 视频流清晰度定义, 取值：FD(流畅)，LD(标清)，SD(高清)，HD(超清)，OD(原画)，2K(2K)，4K(4K)
            /// </summary>
            public string Definition { get; set; }

            /// <summary>
            /// 视频流长度，单位秒
            /// </summary>
            public string Duration { get; set; }

            /// <summary>
            /// 视频流是否加密流，取值：0(否)，1(是)
            /// </summary>
            public string Encrypt { get; set; }

            /// <summary>
            /// 视频流的播放地址
            /// </summary>
            public string PlayURL { get; set; }

            /// <summary>
            /// 视频流格式，若媒体文件为视频则取值：mp4, m3u8，若是纯音频则取值：mp3
            /// </summary>
            public string Format { get; set; }

            /// <summary>
            /// 视频流帧率，每秒多少帧
            /// </summary>
            public string Fps { get; set; }

            /// <summary>
            /// 视频流大小，单位Byte
            /// </summary>
            public string Size { get; set; }

            /// <summary>
            /// 视频流宽度，单位px
            /// </summary>
            public string Width { get; set; }

            /// <summary>
            /// 视频流高度，单位px
            /// </summary>
            public string Height { get; set; }

            /// <summary>
            /// 视频流类型，若媒体流为视频则取值：video，若是纯音频则取值：audio
            /// </summary>
            public string StreamType { get; set; }

            /// <summary>
            /// 媒体流转码的作业ID，作为媒体流的唯一标识
            /// </summary>
            public string JobId { get; set; }

        }

        /// <summary>
        /// 视频基本信息
        /// </summary>
        public class VideoBase
        {
            /// <summary>
            /// 视频ID
            /// </summary>
            public string VideoId { get; set; }

            /// <summary>
            /// 视频标题
            /// </summary>
            public string Title { get; set; }

            /// <summary>
            /// 视频时长(秒)
            /// </summary>
            public string Duration { get; set; }

            /// <summary>
            /// 视频封面
            /// </summary>
            public string CoverURL { get; set; }

            /// <summary>
            /// 视频状态
            /// </summary>
            /// <remarks>
            /// Uploading:上传中|视频的初始状态，表示正在上传;
            /// UploadFail:上传失败|由于是断点续传，无法确定上传是否失败，故暂不会出现此值;
            /// UploadSucc:上传完成;Transcoding 转码中;TranscodeFail:转码失败 转码失败，一般是原片有问题，可在事件通知的转码完成消息得到ErrorMessage失败信息，或提交工单联系我们;
            /// Checking:审核中|在“视频点播控制台-全局设置-审核设置”开启了“先审后发”，转码成功后视频状态会变成审核中，此时视频只能在控制台播放;
            /// Blocked:屏蔽|在审核时屏蔽视频;
            /// Normal 正常  视频可正常播放
            /// </remarks>
            public string Status { get; set; }

            /// <summary>
            /// 视频创建时间，为UTC时间
            /// </summary>
            public string CreationTime { get; set; }

            /// <summary>
            /// 媒体文件类型，取值：video(视频)，audio(纯音频)
            /// </summary>
            public string MediaType { get; set; }
        }

        public class PlayInfoList
        {
            public List<PlayInfoItem> PlayInfo { get; set; }
        }

        public class VideoUrlResult
        {
            /// <summary>
            /// 请求ID
            /// </summary>
            public string RequestId { get; set; }

            /// <summary>
            /// 视频基本信息
            /// </summary>
            public VideoBase VideoBase { get; set; }

            /// <summary>
            /// 视频流信息列表            
            /// </summary>
            public PlayInfoList PlayInfoList { get; set; }

        }
    }
}
