# 🍽️ SignalR Restaurant Management System

Modern ve gerçek zamanlı restoran yönetim sistemi. ASP.NET Core, SignalR, ve Entity Framework Core kullanılarak geliştirilmiş, kapsamlı bir web uygulaması.

## 📋 İçindekiler

- [Özellikler](#-özellikler)
- [Teknoloji Stack](#-teknoloji-stack)
- [Proje Yapısı](#-proje-yapısı)
- [Kurulum](#-kurulum)
- [Kullanım](#-kullanım)
- [API Endpoints](#-api-endpoints)
- [SignalR Özellikleri](#-signalr-özellikleri)
- [Ekran Görüntüleri](#-ekran-görüntüleri)
- [Veritabanı Yapısı](#-veritabanı-yapısı)
- [Mimari ve Tasarım Desenleri](#-mimari-ve-tasarım-desenleri)

## ✨ Özellikler

### 🎯 Gerçek Zamanlı Özellikler (SignalR)
- **Canlı İstatistikler** - Anlık sipariş, ürün ve gelir istatistikleri
- **Masa Durumu Takibi** - Gerçek zamanlı masa doluluk bilgileri
- **Bildirim Sistemi** - Anlık bildirimler ve uyarılar
- **Mesajlaşma** - Gerçek zamanlı dahili iletişim
- **Sipariş Takibi** - Canlı sipariş güncellemeleri

### 🏪 Restoran Yönetimi
- **Ürün Yönetimi** - Menü öğeleri, kategoriler, fiyatlandırma
- **Kategori Yönetimi** - Ürün kategorileri ve organizasyon
- **Masa Yönetimi** - Masa durumu ve rezervasyon takibi
- **Sipariş Yönetimi** - Sipariş alma, işleme ve tamamlama
- **Rezervasyon Sistemi** - Online masa rezervasyonu
- **İndirim Yönetimi** - Promosyon ve kampanya yönetimi

### 💰 İşletme Özellikleri
- **Kasa Yönetimi** - Gelir ve nakit takibi
- **İstatistik ve Raporlama** - Detaylı analiz ve raporlar
- **Sepet Sistemi** - Müşteri sepeti ve sipariş oluşturma
- **Müşteri Yorumları** - Testimonial yönetimi

### 🔧 Teknik Özellikler
- **QR Kod Oluşturma** - Masa ve menü için QR kodlar
- **E-posta Entegrasyonu** - Otomatik bildirimler ve onaylar
- **Kullanıcı Yönetimi** - ASP.NET Identity ile kimlik doğrulama
- **API Dokümantasyonu** - Swagger/OpenAPI entegrasyonu
- **Validasyon** - FluentValidation ile veri doğrulama
- **AutoMapper** - Otomatik nesne dönüşümleri

## 🛠️ Teknoloji Stack

### Backend (API)
- **Framework:** .NET 8.0
- **Web Framework:** ASP.NET Core Web API
- **ORM:** Entity Framework Core 8.0.17
- **Veritabanı:** SQL Server
- **Real-time:** SignalR
- **Mapping:** AutoMapper 12.0.0
- **Validation:** FluentValidation 12.1.1
- **API Docs:** Swashbuckle (Swagger)
- **CORS:** Cross-Origin Resource Sharing desteği

### Frontend
- **Framework:** ASP.NET Core MVC (.NET 8.0)
- **Authentication:** ASP.NET Identity + Cookie Authentication
- **UI Template:** Ready Bootstrap Dashboard
- **QR Code:** QRCoder
- **Email:** MailKit (NETCore.MailKit 2.1.0)
- **Image Processing:** System.Drawing.Common
- **Client Library:** SignalR JavaScript Client

### Veri Katmanı
- **ORM:** Entity Framework Core 8.0.17
- **Database:** SQL Server (DbSignalR)
- **Identity:** ASP.NET Core Identity
- **Pattern:** Repository Pattern
- **Generic Repository:** CRUD soyutlaması

## 📁 Proje Yapısı

```
SignalRProjectRestaurant/
│
├── SignalRProjectRestaurant.API/
│   └── SignalRApi/                         # RESTful API ve SignalR Hub
│       ├── Controllers/                    # API Controller'ları (17 adet)
│       ├── Hubs/                          # SignalR Hub
│       │   └── SignalRHub.cs             # Gerçek zamanlı iletişim hub'ı
│       ├── Mapping/                       # AutoMapper profilleri
│       └── Program.cs                     # API yapılandırması
│
├── SignalRProjectRestaurant.Frontend/
│   └── SignalRFrontend/                    # ASP.NET Core MVC Frontend
│       ├── Controllers/                    # MVC Controller'ları
│       ├── Views/                         # Razor görünümleri
│       │   ├── AdminCategory/            # Kategori yönetimi
│       │   ├── AdminProduct/             # Ürün yönetimi
│       │   ├── AdminBooking/             # Rezervasyon yönetimi
│       │   ├── AdminMenuTable/           # Masa yönetimi
│       │   ├── Menu/                     # Müşteri menüsü
│       │   ├── Basket/                   # Sepet
│       │   ├── Order/                    # Sipariş
│       │   ├── Statistic/                # İstatistikler
│       │   └── ...                       # 30+ görünüm klasörü
│       └── wwwroot/                       # Statik dosyalar
│
└── SignalRProjectRestaurant.Layers/
    │
    ├── EntityLayer/                        # Domain Varlıkları
    │   ├── Entities/                      # 19 adet entity
    │   │   ├── About.cs
    │   │   ├── Product.cs
    │   │   ├── Category.cs
    │   │   ├── Order.cs
    │   │   ├── Booking.cs
    │   │   ├── MenuTable.cs
    │   │   ├── MoneyCase.cs
    │   │   ├── Notification.cs
    │   │   └── ...
    │   └── AppUser.cs / AppRole.cs        # Identity entities
    │
    ├── DataAccessLayer/                    # Veri Erişim Katmanı
    │   ├── Abstract/                      # Repository interface'leri
    │   ├── Concrete/                      # Repository implementasyonları
    │   │   ├── Context/
    │   │   │   └── SignalRContext.cs     # EF Core DbContext
    │   │   └── Repositories/             # Generic ve özel repository'ler
    │   └── Migrations/                    # EF Core migration'ları
    │
    ├── BusinessLayer/                      # İş Mantığı Katmanı
    │   ├── Abstract/                      # Service interface'leri
    │   ├── Concrete/                      # Manager sınıfları
    │   ├── ValidationRules/               # FluentValidation kuralları
    │   │   └── BookingValidations/
    │   │       └── CreateBookingValidation.cs
    │   └── Container/
    │       └── Extensions.cs              # Dependency Injection
    │
    └── DtoLayer/                           # Data Transfer Objects
        └── Dtos/                          # Entity başına 4 DTO
            ├── AboutDto/
            ├── ProductDto/
            ├── CategoryDto/
            └── ...                        # 50+ DTO sınıfı
```

## 🚀 Kurulum

### Gereksinimler

- **.NET 8.0 SDK** veya üzeri
- **SQL Server** 2019 veya üzeri
- **Visual Studio 2022** (önerilen) veya Visual Studio Code
- **Git**

### Adım Adım Kurulum

1. **Projeyi Klonlayın**
   ```bash
   git clone https://github.com/YOUR_USERNAME/SignalRProjectRestaurant.git
   cd SignalRProjectRestaurant
   ```

2. **Veritabanı Bağlantı Ayarları**

   `SignalRProjectRestaurant.Layers/DataAccessLayer/Concrete/Context/SignalRContext.cs` dosyasındaki connection string'i düzenleyin:

   ```csharp
   optionsBuilder.UseSqlServer("Server=YOUR_SERVER_NAME;initial Catalog=DbSignalR;integrated Security=true;TrustServerCertificate=true");
   ```

3. **Veritabanını Oluşturun**

   Package Manager Console'da:
   ```powershell
   Update-Database
   ```

   veya CLI ile:
   ```bash
   dotnet ef database update --project SignalRProjectRestaurant.Layers/DataAccessLayer
   ```

4. **E-posta Ayarlarını Yapılandırın** (Opsiyonel)

   `SignalRFrontend/Controllers/MailController.cs` dosyasındaki SMTP ayarlarını düzenleyin:
   ```csharp
   Host = "smtp.gmail.com",
   Port = 587,
   EnableSsl = true,
   Credentials = new NetworkCredential("your-email@gmail.com", "your-app-password")
   ```

5. **Projeleri Derleyin**
   ```bash
   dotnet build
   ```

6. **API Projesini Çalıştırın**
   ```bash
   cd SignalRProjectRestaurant.API/SignalRApi
   dotnet run
   ```

   API şu adreste çalışacaktır: `https://localhost:7298` veya `http://localhost:5261`

7. **Frontend Projesini Çalıştırın**

   Yeni bir terminal penceresi açın:
   ```bash
   cd SignalRProjectRestaurant.Frontend/SignalRFrontend
   dotnet run
   ```

   Frontend şu adreste çalışacaktır: `https://localhost:7049` veya `http://localhost:5000`

### 🎯 Hızlı Başlangıç

1. Tarayıcınızda `https://localhost:7049` adresine gidin
2. **Kayıt Ol** sayfasından yeni bir hesap oluşturun
3. **Admin Panel**'e giriş yapın
4. **Kategoriler** ve **Ürünler** ekleyin
5. **Masalar** oluşturun
6. **İstatistikler** sayfasında gerçek zamanlı verileri görüntüleyin

## 📖 Kullanım

### Admin Panel Modülleri

#### 📦 Kategori Yönetimi (`/AdminCategory`)
- Kategori ekleme, düzenleme, silme
- Aktif/Pasif durum yönetimi

#### 🍕 Ürün Yönetimi (`/AdminProduct`)
- Ürün CRUD işlemleri
- Fiyat yönetimi
- Kategori ilişkilendirme
- Ürün durumu (aktif/pasif)

#### 🪑 Masa Yönetimi (`/AdminMenuTable`)
- Masa oluşturma ve düzenleme
- Masa durumu (boş/dolu)
- Gerçek zamanlı durum güncellemeleri

#### 📅 Rezervasyon Yönetimi (`/AdminBooking`)
- Rezervasyon listesi
- Onay/Red işlemleri
- Müşteri bilgileri yönetimi

#### 📊 İstatistikler (`/Statistic`)
- Kategori sayıları
- Ürün istatistikleri
- Sipariş analizleri
- Gelir raporları
- Masa kullanım oranları

#### 🔔 Bildirimler (`/AdminNotification`)
- Gerçek zamanlı bildirim listesi
- Okundu/Okunmadı durumu
- Bildirim detayları

### Müşteri Özellikleri

#### 🍽️ Menü Görüntüleme (`/Menu`)
- Kategori bazlı ürün listeleme
- Ürün detayları ve fiyatları
- Sepete ekleme

#### 🛒 Sepet (`/Basket`)
- Ürün ekleme/çıkarma
- Miktar güncelleme
- Toplam fiyat hesaplama

#### 📝 Sipariş (`/Order`)
- Sipariş oluşturma
- Sipariş özeti
- Ödeme işlemi

#### 📞 Rezervasyon (`/BookATable`)
- Online masa rezervasyonu
- Tarih ve saat seçimi
- Kişi sayısı belirtme
- E-posta onayı

## 🔌 API Endpoints

### Swagger Dokümantasyonu
API dokümantasyonuna şu adresten ulaşabilirsiniz: `https://localhost:7298/swagger`

### Temel Endpoint'ler

#### Ürünler (Products)
```http
GET    /api/Product                                 # Tüm ürünleri listele
GET    /api/Product/{id}                           # ID'ye göre ürün getir
GET    /api/Product/ProductListWithCategory        # Kategori bilgileriyle ürünler
POST   /api/Product                                 # Yeni ürün ekle
PUT    /api/Product                                 # Ürün güncelle
DELETE /api/Product/{id}                           # Ürün sil
GET    /api/Product/ProductCount                   # Toplam ürün sayısı
GET    /api/Product/ProductPriceAvg                # Ortalama ürün fiyatı
GET    /api/Product/ProductNameByMaxPrice          # En pahalı ürün
GET    /api/Product/ProductNameByMinPrice          # En ucuz ürün
GET    /api/Product/GetFirst9Product               # İlk 9 ürün (öne çıkanlar)
```

#### Kategoriler (Categories)
```http
GET    /api/Category              # Tüm kategorileri listele
GET    /api/Category/{id}         # ID'ye göre kategori getir
POST   /api/Category              # Yeni kategori ekle
PUT    /api/Category              # Kategori güncelle
DELETE /api/Category/{id}         # Kategori sil
GET    /api/Category/CategoryCount       # Toplam kategori sayısı
GET    /api/Category/ActiveCategoryCount # Aktif kategori sayısı
GET    /api/Category/PassiveCategoryCount # Pasif kategori sayısı
```

#### Rezervasyonlar (Bookings)
```http
GET    /api/Booking               # Tüm rezervasyonları listele
GET    /api/Booking/{id}          # ID'ye göre rezervasyon getir
POST   /api/Booking               # Yeni rezervasyon ekle
PUT    /api/Booking               # Rezervasyon güncelle
DELETE /api/Booking/{id}          # Rezervasyon sil
```

#### Siparişler (Orders)
```http
GET    /api/Order                 # Tüm siparişleri listele
GET    /api/Order/{id}            # ID'ye göre sipariş getir
POST   /api/Order                 # Yeni sipariş ekle
PUT    /api/Order                 # Sipariş güncelle
DELETE /api/Order/{id}            # Sipariş sil
GET    /api/Order/TotalOrderCount        # Toplam sipariş sayısı
GET    /api/Order/ActiveOrderCount       # Aktif sipariş sayısı
GET    /api/Order/LastOrderPrice         # Son sipariş fiyatı
GET    /api/Order/TodayTotalPrice        # Bugünün toplam geliri
```

#### Masalar (MenuTables)
```http
GET    /api/MenuTable             # Tüm masaları listele
GET    /api/MenuTable/{id}        # ID'ye göre masa getir
POST   /api/MenuTable             # Yeni masa ekle
PUT    /api/MenuTable             # Masa güncelle
DELETE /api/MenuTable/{id}        # Masa sil
GET    /api/MenuTable/MenuTableCount     # Toplam masa sayısı
```

#### Sepet (Basket)
```http
GET    /api/Basket                # Sepet öğelerini listele
GET    /api/Basket/{id}           # ID'ye göre sepet öğesi getir
POST   /api/Basket                # Sepete ürün ekle
DELETE /api/Basket/{id}           # Sepetten ürün çıkar
GET    /api/Basket/GetBasketByMenuTableNumber/{id}  # Masa numarasına göre sepet
```

#### Bildirimler (Notifications)
```http
GET    /api/Notification          # Tüm bildirimleri listele
GET    /api/Notification/NotificationCountByStatusFalse  # Okunmamış bildirim sayısı
GET    /api/Notification/GetAllNotificationByFalse       # Okunmamış bildirimleri getir
POST   /api/Notification          # Yeni bildirim ekle
DELETE /api/Notification/{id}     # Bildirim sil
PUT    /api/Notification/NotificationStatusChangeToTrue/{id}  # Okundu olarak işaretle
PUT    /api/Notification/NotificationStatusChangeToFalse/{id} # Okunmadı olarak işaretle
```

#### Diğer Endpoint'ler
```http
# About (Hakkımızda)
GET/POST/PUT/DELETE /api/About

# Contact (İletişim)
GET/POST/PUT/DELETE /api/Contact

# SocialMedia (Sosyal Medya)
GET/POST/PUT/DELETE /api/SocialMedia

# Testimonial (Yorumlar)
GET/POST/PUT/DELETE /api/Testimonial

# Slider (Carousel)
GET/POST/PUT/DELETE /api/Slider

# Discount (İndirimler)
GET/POST/PUT/DELETE /api/Discount

# Message (Mesajlar)
GET/POST/PUT/DELETE /api/Message

# MoneyCase (Kasa)
GET/POST/PUT/DELETE /api/MoneyCase
GET /api/MoneyCase/TotalMoneyCaseAmount  # Toplam kasa tutarı
```

## 📡 SignalR Özellikleri

### Hub Bağlantısı
**Hub URL:** `https://localhost:7298/signalrhub`

### SignalR Metodları

#### 1. SendStatistic()
16 farklı istatistik verisini gerçek zamanlı olarak yayınlar:

```javascript
connection.on("ReceiveCategoryCount", (value) => {
    // Toplam kategori sayısı
});

connection.on("ReceiveProductCount", (value) => {
    // Toplam ürün sayısı
});

connection.on("ReceiveActiveCategoryCount", (value) => {
    // Aktif kategori sayısı
});

connection.on("ReceivePassiveCategoryCount", (value) => {
    // Pasif kategori sayısı
});

connection.on("ReceiveProductFirinCount", (value) => {
    // Fırın kategorisindeki ürün sayısı
});

connection.on("ReceiveProductDrinkCount", (value) => {
    // İçecek kategorisindeki ürün sayısı
});

connection.on("ReceiveProductPriceAvg", (value) => {
    // Ortalama ürün fiyatı
});

connection.on("ReceiveProductNameByMaxPrice", (value) => {
    // En pahalı ürün adı
});

connection.on("ReceiveProductNameByMinPrice", (value) => {
    // En ucuz ürün adı
});

connection.on("ReceiveProductPriceAvgFirin", (value) => {
    // Fırın kategorisi ortalama fiyat
});

connection.on("ReceiveTotalOrderCount", (value) => {
    // Toplam sipariş sayısı
});

connection.on("ReceiveActiveOrderCount", (value) => {
    // Aktif sipariş sayısı
});

connection.on("ReceiveLastOrderPrice", (value) => {
    // Son sipariş fiyatı
});

connection.on("ReceiveTotalMoneyCaseAmount", (value) => {
    // Toplam kasa tutarı
});

connection.on("ReceiveTodayTotalPrice", (value) => {
    // Bugünün toplam geliri
});

connection.on("ReceiveMenuTableCount", (value) => {
    // Toplam masa sayısı
});
```

#### 2. SendProgress()
İlerleme çubukları için veri gönderir:

```javascript
connection.on("ReceiveTotalMoneyCaseAmount", (value) => {
    // Kasa durumu
});

connection.on("ReceiveActiveOrderCount", (value) => {
    // Aktif sipariş sayısı
});

connection.on("ReceiveProductPriceAvg", (value) => {
    // Ortalama ürün fiyatı
});
```

#### 3. GetBookingList()
Rezervasyon listesini gerçek zamanlı günceller:

```javascript
connection.on("ReceiveBookingList", (bookings) => {
    // Rezervasyon listesi
});
```

#### 4. SendNotification()
Bildirim sistemi:

```javascript
connection.on("ReceiveNotificationCountByFalse", (count) => {
    // Okunmamış bildirim sayısı
});

connection.on("ReceiveNotificationListByFalse", (notifications) => {
    // Okunmamış bildirimler listesi
});
```

#### 5. GetMenuTableStatus()
Masa durumu takibi:

```javascript
connection.on("ReceiveMenuTableStatus", (tables) => {
    // Masa durum listesi
});
```

#### 6. SendMessage()
Mesajlaşma sistemi:

```javascript
connection.on("ReceiveMessage", (messages) => {
    // Mesaj listesi
});
```

#### 7. Bağlantı Sayacı
Aktif kullanıcı sayısını takip eder:

```javascript
connection.on("ReceiveClientCount", (count) => {
    // Bağlı kullanıcı sayısı
});
```

### JavaScript Client Örneği

```javascript
// SignalR bağlantısı oluştur
var connection = new signalR.HubConnectionBuilder()
    .withUrl("https://localhost:7298/signalrhub")
    .build();

// Bağlantıyı başlat
connection.start()
    .then(() => {
        console.log("SignalR bağlantısı başarılı!");

        // İstatistikleri almak için metodu çağır
        connection.invoke("SendStatistic");
    })
    .catch(err => console.error(err));

// İstatistik verilerini dinle
connection.on("ReceiveProductCount", (value) => {
    document.getElementById("productCount").innerText = value;
});

connection.on("ReceiveCategoryCount", (value) => {
    document.getElementById("categoryCount").innerText = value;
});

// Otomatik yenileme - Her 5 saniyede bir
setInterval(() => {
    connection.invoke("SendStatistic");
}, 5000);
```

## 📸 Ekran Görüntüleri

### Ana Sayfa

![3](https://github.com/user-attachments/assets/a698ff7e-6027-49cd-92f7-3319e067fe28)


### Admin Paneli - Dashboard

![2](https://github.com/user-attachments/assets/e1a72860-fce2-4ce2-94d9-959d510dcddf)


### Masa Yönetimi

![6](https://github.com/user-attachments/assets/6c2f2bfd-a21e-41ba-aefb-cf52720d8d96)


### Rezervasyon Yönetimi

![5](https://github.com/user-attachments/assets/b385e6ee-8214-41cc-a1a6-c7e33b028e5b)


### Login / Register

![1](https://github.com/user-attachments/assets/3bb0b0a6-7f93-40c6-97e7-6152e9f02bd5)


### API Swagger Dokumentasyonu

![swagger](https://github.com/user-attachments/assets/8dfbc6d0-d530-46d1-b363-fa2c8bac4fad)

### Error 404 Sayfası

![7](https://github.com/user-attachments/assets/1e7e6a5b-2c9d-40ea-b1a8-04982844b633)


## 🗄️ Veritabanı Yapısı

### Temel Tablolar

#### Products (Ürünler)
- ProductID (PK)
- ProductName
- Description
- Price
- ImageUrl
- ProductStatus (bool)
- CategoryID (FK)

#### Categories (Kategoriler)
- CategoryID (PK)
- CategoryName
- CategoryStatus (bool)

#### MenuTables (Masalar)
- MenuTableID (PK)
- Name
- Status (bool)

#### Orders (Siparişler)
- OrderID (PK)
- TableNumber
- Description
- OrderDate
- TotalPrice
- OrderStatus

#### OrderDetails (Sipariş Detayları)
- OrderDetailID (PK)
- ProductID (FK)
- Count
- UnitPrice
- TotalPrice
- OrderID (FK)

#### Bookings (Rezervasyonlar)
- BookingID (PK)
- Name
- Phone
- Mail
- PersonCount
- Date
- Description

#### Basket (Sepet)
- BasketID (PK)
- Price
- Count
- TotalPrice
- ProductID (FK)
- MenuTableID (FK)

#### Notifications (Bildirimler)
- NotificationID (PK)
- Type
- Description
- Date
- Status (bool - okundu/okunmadı)

#### Messages (Mesajlar)
- MessageID (PK)
- NameSurname
- Mail
- Phone
- Subject
- MessageContent
- MessageSendDate
- Status (bool)

#### MoneyCase (Kasa)
- MoneyCaseID (PK)
- TotalAmount

#### About (Hakkımızda)
- AboutID (PK)
- ImageUrl
- Title
- Description

#### Contact (İletişim)
- ContactID (PK)
- Location
- Phone
- Mail
- FooterTitle
- FooterDescription
- OpenDays
- OpenDaysDescription
- OpenHours

#### SocialMedia (Sosyal Medya)
- SocialMediaID (PK)
- Title
- Url
- Icon

#### Testimonials (Müşteri Yorumları)
- TestimonialID (PK)
- Name
- Title
- Comment
- ImageUrl
- Status (bool)

#### Sliders (Carousel)
- SliderID (PK)
- Title1
- Title2
- Title3
- Description1
- Description2
- Description3

#### Discounts (İndirimler)
- DiscountID (PK)
- Title
- Amount
- Description
- ImageUrl
- Status (bool)

#### Features (Özellikler)
- FeatureID (PK)
- Title1
- Description1
- Title2
- Description2
- Title3
- Description3

### Identity Tabloları
- AspNetUsers (AppUser)
- AspNetRoles (AppRole)
- AspNetUserRoles
- AspNetUserClaims
- AspNetRoleClaims

## 🏗️ Mimari ve Tasarım Desenleri

### N-Layer Architecture (Katmanlı Mimari)

Proje, **4 katmanlı mimari** kullanır:

```
┌─────────────────────────────────────────┐
│     Presentation Layer (API/MVC)        │  ← Controllers, Views, Hub
├─────────────────────────────────────────┤
│     Business Logic Layer                │  ← Services, Managers, Validation
├─────────────────────────────────────────┤
│     Data Access Layer                   │  ← Repositories, EF Core Context
├─────────────────────────────────────────┤
│     Entity Layer + DTO Layer            │  ← Domain Models, DTOs
└─────────────────────────────────────────┘
```

### Repository Pattern

**Generic Repository** ile CRUD soyutlaması:

```csharp
public interface IGenericDal<T> where T : class
{
    void Insert(T entity);
    void Delete(T entity);
    void Update(T entity);
    List<T> GetListAll();
    T GetByID(int id);
}

public class GenericRepository<T> : IGenericDal<T> where T : class
{
    private readonly SignalRContext _context;
    // Implementation...
}
```

**Özel Repository'ler** (örnek):

```csharp
public interface IProductDal : IGenericDal<Product>
{
    List<Product> GetProductsWithCategories();
    int ProductCountByDrinkCategory();
    decimal ProductPriceAvg();
    string ProductNameByMaxPrice();
    // Özel sorgular...
}
```

### Service/Manager Pattern

Her entity için **Service Interface** ve **Manager** implementasyonu:

```csharp
// Interface
public interface IProductService : IGenericService<Product>
{
    List<Product> TGetProductsWithCategories();
    int TProductCount();
    // Özel metodlar...
}

// Manager (Business Logic)
public class ProductManager : IProductService
{
    private readonly IProductDal _productDal;

    public ProductManager(IProductDal productDal)
    {
        _productDal = productDal;
    }

    public List<Product> TGetProductsWithCategories()
    {
        return _productDal.GetProductsWithCategories();
    }
    // Business logic...
}
```

### DTO Pattern

Her entity için **4 farklı DTO**:

```
ProductDto/
├── CreateProductDto.cs       # POST istekleri için
├── UpdateProductDto.cs       # PUT istekleri için
├── ResultProductDto.cs       # Liste sorguları için
└── GetProductDto.cs          # Tekil sorgu için
```

**Avantajları:**
- Entity'lerin korunması
- Over-posting saldırılarının önlenmesi
- API versiyon yönetimi
- Validation ayrımı

### Dependency Injection (DI)

Tüm servisler **Scoped** olarak kaydedilir:

```csharp
// Extensions.cs
public static void ContainerDependencies(this IServiceCollection services)
{
    services.AddScoped<IAboutService, AboutManager>();
    services.AddScoped<IAboutDal, EfAboutDal>();

    services.AddScoped<IProductService, ProductManager>();
    services.AddScoped<IProductDal, EfProductDal>();

    // 17 servis kaydı...
}
```

**Program.cs'te kullanım:**
```csharp
builder.Services.ContainerDependencies();
```

### AutoMapper

**Mapping Profilleri:**

```csharp
public class ProductMapping : Profile
{
    public ProductMapping()
    {
        CreateMap<Product, ResultProductDto>().ReverseMap();
        CreateMap<Product, CreateProductDto>().ReverseMap();
        CreateMap<Product, GetProductDto>().ReverseMap();
        CreateMap<Product, UpdateProductDto>().ReverseMap();
        CreateMap<Product, ResultProductWithCategory>()
            .ForMember(dest => dest.CategoryName,
                      opt => opt.MapFrom(src => src.Category.CategoryName));
    }
}
```

**Controller'da kullanım:**
```csharp
var values = _mapper.Map<List<ResultProductDto>>(_productService.TGetListAll());
```

### FluentValidation

**Validation Rule Örneği:**

```csharp
public class CreateBookingValidation : AbstractValidator<CreateBookingDto>
{
    public CreateBookingValidation()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("İsim alanı boş geçilemez")
            .MinimumLength(5).WithMessage("İsim en az 5 karakter olmalıdır")
            .MaximumLength(50).WithMessage("İsim en fazla 50 karakter olmalıdır");

        RuleFor(x => x.Mail)
            .NotEmpty().WithMessage("Mail alanı boş geçilemez")
            .EmailAddress().WithMessage("Geçerli bir e-posta adresi giriniz");

        RuleFor(x => x.Phone)
            .NotEmpty().WithMessage("Telefon alanı boş geçilemez");

        RuleFor(x => x.PersonCount)
            .NotEmpty().WithMessage("Kişi sayısı boş geçilemez");

        RuleFor(x => x.Date)
            .NotEmpty().WithMessage("Tarih alanı boş geçilemez");
    }
}
```

**Program.cs'te aktivasyon:**
```csharp
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
builder.Services.AddValidatorsFromAssemblyContaining<CreateBookingValidation>();
```

### SOLID Prensipleri

#### Single Responsibility Principle (SRP)
- Her sınıf tek bir sorumluluğa sahip
- Controller'lar sadece HTTP isteklerini yönetir
- Manager'lar sadece iş mantığını içerir
- Repository'ler sadece veri erişiminden sorumlu

#### Open/Closed Principle (OCP)
- Generic repository ile genişletilebilir yapı
- Yeni entity ekleme için mevcut kodu değiştirmeye gerek yok

#### Liskov Substitution Principle (LSP)
- Interface'ler ve base class'lar doğru implemente edilmiş
- Türetilmiş sınıflar base sınıfların yerine kullanılabilir

#### Interface Segregation Principle (ISP)
- Her entity için özel interface'ler
- Kullanılmayan metodlar zorlanmaz

#### Dependency Inversion Principle (DIP)
- Yüksek seviye modüller düşük seviye modüllere bağlı değil
- Her şey soyutlama (interface) üzerinden çalışır

## 🔐 Güvenlik

- **ASP.NET Identity** ile kimlik doğrulama
- **Cookie-based Authentication** güvenli oturum yönetimi
- **Role-based Authorization** rol tabanlı yetkilendirme
- **HTTPS** zorunlu
- **CORS** politikaları yapılandırılmış
- **SQL Injection** koruması (EF Core parametreli sorgular)
- **XSS** koruması (Razor otomatik encoding)
- **CSRF** token'ları (ASP.NET Core otomatik)

## 🧪 Test

```bash
# Projeyi test edin
dotnet test

# Coverage raporu oluşturun
dotnet test /p:CollectCoverage=true
```

## 📊 Performans

- **SignalR** ile gerçek zamanlı veri aktarımı
- **AutoMapper** ile hızlı nesne dönüşümleri
- **EF Core** sorgu optimizasyonu
- **Lazy Loading** devre dışı (N+1 problemi önlenir)
- **Eager Loading** ile ilişkili veriler yüklenir
- **Generic Repository** ile kod tekrarı azaltılmış

## 🌐 Tarayıcı Desteği

- ✅ Chrome (önerilen)
- ✅ Firefox
- ✅ Edge
- ✅ Safari
- ⚠️ IE11 (sınırlı destek - SignalR için gereklidir)

## 📝 Geliştirme Notları

### Git Flow

```bash
# Yeni bir özellik dalı oluşturun
git checkout -b feature/yeni-ozellik

# Değişiklikleri commit edin
git add .
git commit -m "Yeni özellik eklendi"

# Master'a merge edin
git checkout master
git merge feature/yeni-ozellik
```

### Veritabanı Migration

```bash
# Yeni migration oluştur
dotnet ef migrations add MigrationName --project DataAccessLayer

# Migration'ı uygula
dotnet ef database update --project DataAccessLayer

# Son migration'ı geri al
dotnet ef migrations remove --project DataAccessLayer
```

### Yeni Entity Ekleme Checklist

- [ ] `EntityLayer/Entities/` klasörüne entity ekle
- [ ] `SignalRContext.cs`'e DbSet ekle
- [ ] Migration oluştur ve uygula
- [ ] `DtoLayer/Dtos/` klasörüne DTO'lar ekle (Create, Update, Result, Get)
- [ ] `DataAccessLayer/Abstract/` klasörüne repository interface'i ekle
- [ ] `DataAccessLayer/Concrete/` klasörüne repository implementasyonu ekle
- [ ] `BusinessLayer/Abstract/` klasörüne service interface'i ekle
- [ ] `BusinessLayer/Concrete/` klasörüne manager ekle
- [ ] `Extensions.cs`'e DI kaydı ekle
- [ ] AutoMapper profili oluştur
- [ ] API Controller ekle
- [ ] Frontend Controller ve View'lar ekle (gerekirse)

## 🤝 Katkıda Bulunma

Katkılarınızı bekliyoruz! Lütfen şu adımları izleyin:

1. Projeyi fork edin
2. Feature branch oluşturun (`git checkout -b feature/AmazingFeature`)
3. Değişikliklerinizi commit edin (`git commit -m 'feat: Add some AmazingFeature'`)
4. Branch'inizi push edin (`git push origin feature/AmazingFeature`)
5. Pull Request oluşturun

### Commit Mesaj Formatı

```
feat: Yeni özellik eklendi
fix: Bir hata düzeltildi
docs: Dokümantasyon güncellendi
style: Kod formatı düzeltildi
refactor: Kod yeniden yapılandırıldı
test: Test eklendi veya güncellendi
chore: Build veya araç güncellemeleri
```

## 📄 Lisans

Bu proje [MIT](LICENSE) lisansı altında lisanslanmıştır.

## 👨‍💻 Geliştirici

**İsmail**
- GitHub: [@ismaildundar42](https://github.com/ismaildundar42)
- Email: ismail.dndr42@gmail.com

## 🙏 Teşekkürler

- [ASP.NET Core](https://dotnet.microsoft.com/apps/aspnet) - Web framework
- [SignalR](https://dotnet.microsoft.com/apps/aspnet/signalr) - Real-time communication
- [Entity Framework Core](https://docs.microsoft.com/ef/core/) - ORM
- [AutoMapper](https://automapper.org/) - Object mapping
- [FluentValidation](https://fluentvalidation.net/) - Validation library
- [QRCoder](https://github.com/codebude/QRCoder) - QR code generation
- [MailKit](https://github.com/jstedfast/MailKit) - Email library
- [Ready Bootstrap Dashboard](https://themesflat.co/) - UI template

## 📚 Kaynaklar

- [ASP.NET Core Dokümantasyon](https://docs.microsoft.com/aspnet/core)
- [SignalR Dokümantasyon](https://docs.microsoft.com/aspnet/core/signalr)
- [EF Core Dokümantasyon](https://docs.microsoft.com/ef/core)
- [C# Programlama Dilleri Rehberi](https://docs.microsoft.com/dotnet/csharp)

## 🔄 Versiyon Geçmişi

### v1.0.0 (Mevcut)
- ✅ N-Layer Architecture implementasyonu
- ✅ SignalR gerçek zamanlı özellikler
- ✅ 17 API endpoint'i
- ✅ Admin panel ve müşteri arayüzü
- ✅ AutoMapper entegrasyonu
- ✅ FluentValidation implementasyonu
- ✅ QR kod oluşturma
- ✅ E-posta gönderimi
- ✅ ASP.NET Identity entegrasyonu
- ✅ Swagger API dokümantasyonu

### Gelecek Sürümler (Roadmap)
- 🔜 Unit test coverage artırımı
- 🔜 Docker containerization
- 🔜 CI/CD pipeline
- 🔜 Redis cache entegrasyonu
- 🔜 Elasticsearch log yönetimi
- 🔜 Mobile app (React Native / Flutter)
- 🔜 Payment gateway entegrasyonu
- 🔜 Multi-language support
- 🔜 PWA (Progressive Web App) desteği

---

<div align="center">

**⭐ Bu projeyi beğendiyseniz yıldız vermeyi unutmayın! ⭐**

Made with ❤️ by [İsmail](https://github.com/ismaildundar42)

</div>
