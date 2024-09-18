Traversal, kullanıcıların yönetici tarafından oluşturulan seyahat turlarını görüntüleyip rezervasyon yapabilecekleri bir senaryo üzerine kurguladığım web sitesi. Kullanıcılar, farklı tatil turlarını ve detaylarını inceleyebilir, rehber bilgilerini görüntüleyebilir, istedikleri turlara rezervasyon yaptırabilir ve OpenAI API üzerinden çalışan Traversal AI Asistan’dan faydalanarak akıllarındaki sorulara cevap alabilirler. Ayrıca yönetici paneli tarafında ise istatistik görüntüleme ve CRUD işlemleriyle beraber çok çeşitli özellikler bulunuyor.

Projeyi Docker Compose aracılığıyla lokalinizde ayağa kaldırmak için terminalden projenin yml dosyasının yer aldığı dizine erişip aşağıdaki komutu çalıştırabilirsiniz. Ardından tarayıcınızla localhost adresine bağlanın. 

```charp
 docker compose up -d
```
Admin Hesabının kullanıcı adı ve şifresi:
```charp
Kullanıcı Adı: burakarslan0110
Şifre: 8s7k5858K
Admin paneline giriş adresi: localhost/Admin/Dashboard/
```


## Ana Sayfa

![image](https://github.com/user-attachments/assets/02392e4b-6d77-48d2-8de8-e598a431c080)

## Üye Paneli

![image](https://github.com/user-attachments/assets/9b6c5151-cdf5-490c-b647-85ccb860910e)

## Admin Paneli

![image](https://github.com/user-attachments/assets/5bce8938-5e56-4bd3-9ec1-ea89c1d906ea)

Microsoft Azure üzerinden canlıya aldığım Traversal sitemin linki: https://traversal.live

Bu projeyi **ASP.NET Core 8** altında geliştirirken, pek çok kütüphane ve yapıyı detaylı bir şekilde kullanarak özellikle back-end temelimi güçlendirdim. Kullandığım teknolojileri şu şekilde sıralayabilirim:

❇️ Kullanılan Teknolojiler:

 ASP.NET Core 8.0
- N Katmanlı Mimari
- CQRS Tasarım Deseni
- Personel arası prim ücreti aktarımında Unit Of Work Tasarım Deseni
- ORM tarafında Entity Framework Code First
- Veri yönetiminde MSSQL Server
- Siteyi canlıya alırken Azure SQL DB
- Veri girişlerindeki doğrulama için Fluent Validation
- Kullanıcı kimlik doğrulama ve yetkilendirme için Identity
- IMDB verileri için RapidAPI
- Traversal AI Asistan altyapısı için OpenAI API
- Yönetici paneli üzerinden mail ve şifre sıfırlama mail gönderimi için MailKit
- Nesneler arasındaki veri dönüşümü için AutoMapper
- Excel ve PDF raporları oluşturmak için EPPlus ve iTextSharp
- Tasarım tarafında HTML, CSS, JavaScript ve Bootstrap

Ana sayfa haricinde diğer iki ana bileşenin özellikleri ise şu şekilde: 

- Yönetici paneli; istatistikleri görüntüleme, turlar, tur rehber personelleri ve blog içerikleri üzerinde CRUD işlemleri yapma, site üzerindeki tüm yorumları görüntüleme ve kullanıcıları yönetme gibi kapsamlı özellikler sunuyor. Ayrıca, mesajlaşma sistemi, raporlama özellikleri, e-posta gönderme, rezervasyonları yönetme, rol atama gibi işlevler de yönetici panelinde bulunuyor.
- Kullanıcı üye paneli, profil bilgilerini güncelleme, aktif rotaları görüntüleme ve rezervasyon oluşturma gibi işlevlere sahip. Ayrıca, onay bekleyen ve reddedilen rezervasyonları görüntüleme özellikleri ile kullanıcıların rezervasyon sürecini kolayca takip etmelerine olanak sağladım.
