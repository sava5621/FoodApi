using Microsoft.AspNetCore.Mvc;

namespace FoodApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class YandexMapController : ControllerBase
    {
        [HttpGet("byName")]
        public ContentResult Index(string x, string y)
        {
            string buff = $"    <html>\r\n    <head>\r\n        <meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" />\r\n        <title>Создание и удаление</title>\r\n        <script src=\"https://api-maps.yandex.ru/2.1/?lang=ru_RU&amp;apikey=5f4a5006-3f10-4795-a6fc-ba2e71b8ee9f\" type=\"text/javascript\"></script>\r\n        <script>\r\n            x={x}\r\n            y={y}\r\n       ymaps.ready(init);\r\n\r\n    function init() {{\r\n        var myMap = new ymaps.Map(\"map\", {{\r\n                center: [x, y],\r\n                zoom: 10\r\n            }}, {{\r\n                searchControlProvider: 'yandex#search'\r\n            }}),\r\n\r\n        // Создаем геообъект с типом геометрии \"Точка\".\r\n            myPieChart = new ymaps.Placemark([\r\n                x, y\r\n            ], {{\r\n                // Данные для построения диаграммы.\r\n                data: [\r\n                    {{weight: 8, color: '#0E4779'}},\r\n                    {{weight: 6, color: '#1E98FF'}},\r\n                    {{weight: 4, color: '#82CDFF'}}\r\n                ],\r\n                iconCaption: \"Диаграмма\"\r\n            }}, {{\r\n                // Зададим произвольный макет метки.\r\n                iconLayout: 'default#pieChart',\r\n                // Радиус диаграммы в пикселях.\r\n                iconPieChartRadius: 30,\r\n                // Радиус центральной части макета.\r\n                iconPieChartCoreRadius: 10,\r\n                // Стиль заливки центральной части.\r\n                iconPieChartCoreFillStyle: '#ffffff',\r\n                // Cтиль линий-разделителей секторов и внешней обводки диаграммы.\r\n                iconPieChartStrokeStyle: '#ffffff',\r\n                // Ширина линий-разделителей секторов и внешней обводки диаграммы.\r\n                iconPieChartStrokeWidth: 3,\r\n                // Максимальная ширина подписи метки.\r\n                iconPieChartCaptionMaxWidth: 200\r\n            }});\r\n\r\n        myMap.geoObjects\r\n            .add(new ymaps.Placemark([x, y], {{\r\n                balloonContent: 'цвет <strong>голубой</strong>',\r\n                iconCaption: 'Очень длиннный, но невероятно интересный текст'\r\n            }}, {{\r\n                preset: 'islands#blueCircleDotIconWithCaption',\r\n                iconCaptionMaxWidth: '50'\r\n            }}));\r\n    }}\r\n    </script>\r\n        \r\n        <style>\r\n            body, html {{\r\n                padding: 0;\r\n                margin: 0;\r\n                width: 100%;\r\n                height: 100%;\r\n            }}\r\n            #map {{\r\n                width: 100%;\r\n                height: 90%;\r\n            }}\r\n        </style>\r\n    </head>\r\n    <body>\r\n    <div id=\"map\" style=\"width: 100vw; height: 100vh\"></div>\r\n    </body>\r\n    </html>\r\n55.790139";
              return base.Content(buff,
                "text/html; charset=utf-8");
        }
    }
}
