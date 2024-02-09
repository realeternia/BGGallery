using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using HtmlAgilityPack;
using System.Threading.Tasks;

namespace BGGallery.Utils
{
    class BGInfoSyncer
    {
        public static async Task<List<GameInfo>> ExtractGameInfoAsync(string name)
        {
            string url = "https://www.gstonegames.com/game/?keyword=" + name;
            List<GameInfo> games = new List<GameInfo>();

            // 使用 HttpClient 获取 HTML 内容
            string htmlContent = await GetHtmlContentAsync(url);

            // 使用 HtmlAgilityPack 解析 HTML
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(htmlContent);

            // 提取信息
            var gameDivs = doc.DocumentNode.SelectNodes("//div[@class='goods-list fl']");
            if (gameDivs != null)
            {
                foreach (var gameDiv in gameDivs)
                {
                    GameInfo game = new GameInfo();

                    // 提取游戏标题
                    game.Title = gameDiv.SelectSingleNode(".//div[@class='goods-title']/a")?.InnerText.Trim();

                    // 提取游戏详细信息
                    game.Details = gameDiv.SelectSingleNode(".//div[@class='goods01']")?.InnerText.Trim().Replace("&nbsp;", "");

                    // 提取玩家信息
                    game.PlayerInfo = gameDiv.SelectSingleNode(".//div[@class='goods02']")?.InnerText.Trim();
                    // 提取游戏ID
                    game.Id = ExtractGameId(gameDiv.SelectSingleNode(".//div[@class='goods-title']/a")?.GetAttributeValue("href", ""));

                    // 提取游戏图片链接
                    game.ImageUrl = gameDiv.SelectSingleNode(".//div[@class='goods-img']/div/img")?.GetAttributeValue("src", "").Trim();
                  

                    games.Add(game);
                }
            }

            return games;
        }

        static async Task<string> GetHtmlContentAsync(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                return await client.GetStringAsync(url);
            }
        }

        static string ExtractGameId(string href)
        {
            // 提取 "info-" 后面的数字部分作为游戏ID
            int startIndex = href.IndexOf("info-") + 5;
            int endIndex = href.IndexOf(".html");

            if (startIndex != -1 && endIndex != -1)
            {
                return href.Substring(startIndex, endIndex - startIndex);
            }

            return "";
        }
        public static async Task DownloadImageAsync(string imageUrl, string savePath)
        {
            imageUrl = "http:" + imageUrl;
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // 下载图片
                    byte[] imageBytes = await client.GetByteArrayAsync(imageUrl);

                    // 保存图片到本地文件
                    using (FileStream fs = File.Create(savePath))
                    {
                        await fs.WriteAsync(imageBytes, 0, imageBytes.Length);
                        Console.WriteLine("Image saved successfully.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}

public class GameInfo
{
    public string Title { get; set; }
    public string Details { get; set; }
    public string PlayerInfo { get; set; }
    public string ImageUrl { get; set; }
    public string Id { get; set; }

}