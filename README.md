# SahafOtomasyonu

Bu proje, .NET Core kullanılarak geliştirilmiş basit bir kitapçı otomasyon sistemidir. MVC (Model-View-Controller) mimarisi ile tasarlanmış olup, bir kitapçının envanterini yönetmeyi amaçlar. Kullanıcılar kitapları ekleyebilir, silebilir ve düzenleyebilir. Admin kullanıcı ekleyebilir, silebilir ve düzenleyebilir. Proje, kitap yönetimi, kullanıcı yönetimi ve kitap arama özellikleri sunmaktadır.

## Özellikler

- **Kitap Envanteri Yönetimi**: Kitaplar eklenebilir, güncellenebilir ve silinebilir.
- **Arama Fonksiyonu**: Kitaplar, yazar veya türüne göre arama yapılabilir.
- **Kullanıcı Yönetimi**: Admin kullanıcıları ekleyebilir, silebilir ve düzenleyebilir.
- **Kullanıcı Dostu Arayüz**: Basit ve anlaşılır bir kullanıcı arayüzü.
- **Kitap Detayları**: Her kitabın adı, yazarı, türü ve açıklamaları gibi bilgileri görüntüleyebilirsiniz.

## Teknolojiler

Proje aşağıdaki teknolojiler kullanılarak geliştirilmiştir:

- **.NET Core**: Backend uygulama geliştirmek için kullanıldı.
- **MVC (Model-View-Controller)**: Uygulama mimarisi, verileri işleme, görüntüleme ve yönlendirme işlemlerini ayırmak için MVC prensiplerine göre yapılandırılmıştır.
- **C#**: Backend geliştirme dili olarak C# kullanıldı.
- **Entity Framework Core**: Veritabanı işlemleri ve veritabanı bağlantısı için kullanıldı.
- **SQL Server**: Veritabanı olarak SQL Server kullanılmıştır.

## Kurulum

Proje yerel bilgisayarınızda çalıştırmak için aşağıdaki adımları izleyebilirsiniz:

 1. Gereksinimleri Yükleyin

- **.NET Core SDK**'yı indirip kurun: [https://dotnet.microsoft.com/download](https://dotnet.microsoft.com/download)
- **SQL Server**: Veritabanı yönetim sistemi olarak SQL Server gereklidir. [SQL Server'ı buradan indiriniz](https://www.microsoft.com/en-us/sql-server/sql-server-downloads).

 2. Repository'yi Klonlayın

Projeyi yerel bilgisayarınıza klonlamak için aşağıdaki komutu kullanabilirsiniz:

```bash
git clone https://github.com/hazanakpinar/SahafOtomasyonu.git
```
 3. Connection String bağlantınızı yapın 

örnek bağlantı cümlesi

```bash
 string connectionString = "Server=.;Database=DB-ADI;Trusted_Connection=True;TrustServerCertificate=True;"
```
4. Veritabanını oluşturmak için Entity Framework ile gerekli migrasyonları uygulayın.

   ```bash
   add-migration initDB
   ```
     ```bash
   update-database
