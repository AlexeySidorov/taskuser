# task users
# Xamarin Android and iOS
# Задача:

Создать приложение, отображающее список людей с возможностью просмотра информации о каждом конкретном человеке, 
включая список его друзей с возможностью перехода между ними.  Полученные данные должны кешироваться при получении и НЕ 
перезапрашиваться при последующем запуске приложения. На экране списка должна быть обеспечена возможность перезагрузки 
закешированных данных.  Адрес запроса:  https://www.dropbox.com/s/s8g63b149tnbg8x/users.json?dl=0  Общие требования: - 
язык разработки - Xamarin.Android and Xamarin.iOS (C#):

  Версия Android - 5.0+ - требования к дизайну - соответствие гайдлайнам Material Design. 
  Версия iOS - 10+.

Требования к содержанию экранов: 
  1. Экран списка пользователей - представлен в виде списка - каждый элемент списка содержит текст name, текст email и
     отображение состояния isActive - переход на детали пользователя доступен только для активных пользователей (isActive == true)  
  2. Экран деталей пользователя: - содержит текстовые поля name, age, company, email, phone, address и about - нажатие на поле email 
  должно открывать внешний почтовый клиент и добавлять значение поля в качестве адресата письма - нажатие на поле phone должно 
  открывать приложение для звонков и вставлять номер в поле набора - значение поля eyeColor должно быть представлено в виде
  точки соответствующего цвета. Возможные варианты: brown, green, blue - значение поля favoriteFruit должно быть представлено 
  в виде иконки, соответствующей одному из трех вариантов: apple, banana, strawberry - значение поля registered должно быть 
  отформатированно в строковый формат даты HH:mm dd.MM.yy - значение полей latitude и longitude должно выводиться в одну строку 
  по стандартному формату координат и, при нажатии, открывать внешнее приложение карт с отображением данной точки - список friends
  должен выводиться в виде вертикального списка, аналогичного по наполнению и поведению списку, описанному в пункте 1.
  3. Экран списка пользователей - переход по кнопке back должен обеспечивать переход по всей иерархии открытых экранов, 
  а не вести на экран списка

![alt text](https://github.com/AlexeySidorov/taskuser/blob/master/task3_preview.jpg)
