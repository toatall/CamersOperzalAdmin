﻿#Модуль администрирования интернет-сервиса видеонаблюдения за оперзалами Инспекций округа

##Описание
Сервис позволяет выполнять администрирование и настройку интернет-сервиса видеонаблюдения за оперзалами Инспекций округа.

##Основание разработки
Необходимость в управлении данными для интернет-сервиса видеонаблюдения за оперзалами Инспекций округа.

##Функции сервиса
1. Состояние. Показывает текущее состояние всех (включенных) камер. Для каждой камеры выполняется тест (ping) ссылки на получение изображение с камеры.
2. Настройки. Задаются настройки сервиса загрузки изображений. Такие как: интервал загрузки, таймаут загрузки и др.
3. Управление инспекциями. Позволяет манипулировать данными инспекций (CRUD).
4. Управление камерами. Позволяет манипулировать данными камеры (CRUD) относительно выбранной инспекции.
5. Включение и выключение камер. Позволяет включить и отключить отдельную камеру в выбранной инспекции (например, в связи с проведение ремонта или технического обслуживания камеры).

##Изменения
19.12.2017 - разработка

##Требования
Веб-сервер: IIS
>= NETFramework 4.5

##Установка
1. На сервере установить службу Microsoft IIS

##Руководство
[Администрирование интернет-сервиса видео-наблюдения](/doc/Администрирование интернет-сервиса видео-наблюдения.docx)



