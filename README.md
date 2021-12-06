# GarageApp
Приложение для расположения обьектов в гараже

В ветке Master находится настольная версия приложения, реализованная на WPF, язык C#. 
Для создания 3D проекции была использована библиотека Helix Toolkit, код которой можно увидеть здесь: https://github.com/helix-toolkit/helix-toolkit. 
Для разработки клиент-серверного приложения было разработана база данных и API приложение, опубликованное на Azure. Ссылка на API: https://wsrexampleapi.azurewebsites.net/api/users
Перейдя по этой ссылке мы увидим список пользователей, за которых можно авторизироваться в приложении

В ветке Android находится мобильная версия приложения, реализованная на языке Kotlin.

#Как запустить приложение?
###Настольное приложение
1. Перейдите в ветку master-application, нажмите на кнопку **Сode** и выберите пункт **Download ZIP** 
2. После скачивания пакета необходимо перейти в папку, куда вы загрузили архив, найти файл **GarageApp-master-application** и распаковать его.
3. В распакованном пакете необходимо выбрать exe файл и запустить его. 
3.1. При появлении окна авторизации введите данные admin admin, либо зарегистрируйтесь под своими данными

###Мобильное приложение
1. Перейдите в ветку Android-application, нажмите на кнопку **Сode** и выберите пункт **Download ZIP** 
2. После скачивания пакета необходимо перейти в папку, куда вы загрузили архив, найти файл **GarageApp-android-application** и распаковать его.
3. В распакованном пакете необходимо выбрать apk файл и запустить его. Если у вас эмулятор, этого будет достаточно
4. Если у вас обычный телефон, переместите apk файл на андроид и запустите его оттуда.
