#include <Wire.h>//birden fazla veri transferi yapan kütüphane
#include <DHT.h>//dht sensörü kütüphanesi
#define DHTPIN 2 //DHT pin ataması
#define DHTTYPE DHT11 //DHT model ataması
DHT dht(DHTPIN,DHTTYPE);//tanımlama
void setup() {
  Serial.begin(9600);//Protokol
  dht.begin();//
}
void loop() {
  int h = dht.readHumidity(); //Nem değerini oku
  int t = dht.readTemperature(); //Sıcaklık değerini oku
    Serial.print(h);//nem değerini yazdır
    Serial.print("/");//ayırmak için kullanılır.(görüntü amaçlı)
    Serial.println(t);//sıcaklık değerini yazdır.
    delay(1000);//1 saniye aralıklarla ölçüm yapar
}
