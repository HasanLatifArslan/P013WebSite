namespace P013WebSite.Tools
{
    public class FileHelper
    {
        public static async Task<string> FileLoaderAsync(IFormFile formFile, string klasorYolu = "/wwwroot/Img/")
        {
            string dosyaAdi = " ";
            dosyaAdi = formFile.FileName;
            string dizin = Directory.GetCurrentDirectory(); // uygulamamızıın pc de çalıştığı yeri bize getiriyor
            dizin += klasorYolu + dosyaAdi; // yükleme dizinine uygulama içindeki klasör ve dosya adını da ekldik
            using var stream = new FileStream(dizin, FileMode.Create); // pcden server a dosya yükleme için bir akış başlattık
            await formFile.CopyToAsync(stream); // ifomrfile içerisinden gelen ve asenkton çalışan copytoasync metoduna dosya yükleme akışımızı gönderdik ve sunucuya kopyaladık
            return dosyaAdi; // sucunuya yükleen donyanın adını geri döndürdük
        }
    }
}
