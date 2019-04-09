using System.Collections.Generic;
using Unity.UIWidgets.painting;
using Unity.UIWidgets.rendering;
using Unity.UIWidgets.ui;
using Unity.UIWidgets.widgets;
using TextStyle = Unity.UIWidgets.painting.TextStyle;

namespace DocCN.Components
{
    public class Banner : StatelessWidget
    {
        public override Widget build(BuildContext context)
        {
            return new Container(
                padding: EdgeInsets.only(
                    top: 16.0f,
                    right: 48.0f,
                    bottom: 16.0f,
                    left: 48.0f),
                height: 277.0f,
                decoration: new BoxDecoration(
                    color: new Color(0xff000000),
                    image: new DecorationImage(
                        fit: BoxFit.cover,
                        image: new NetworkImage(
                            "http://unitydocstrafficmanagerstaging.trafficmanager.net/publishing/html/env1/img/hero.png")
                    )
                ),
                child: new Column(
                    crossAxisAlignment: CrossAxisAlignment.start,
                    children: new List<Widget>
                    {
                        new Container(
                            margin: EdgeInsets.only(top: 40.0f),
                            height: 72.0f,
                            child: new Align(
                                alignment: Alignment.centerLeft,
                                child: new Text(
                                    "Unity 技术手册",
                                    style: new TextStyle(
                                        color: new Color(0xffffffff),
                                        fontSize: 64.0f,
                                        fontWeight: FontWeight.w700 // actually w600
                                    )
                                )
                            )
                        ),
                        new Container(
                            margin: EdgeInsets.only(top: 32.0f),
                            height: 32.0f,
                            child: new Align(
                                alignment: Alignment.centerLeft,
                                child: new Text(
                                    "技术手册，脚本API和服务手册文档的一站式文档手册。",
                                    style: new TextStyle(
                                        color: new Color(0xffffffff),
                                        fontSize: 18.0f,
                                        fontWeight: FontWeight.w400,
                                        height: 1.77777777778f
                                    )
                                )
                            )
                        ),
                        new Container(
                            margin: EdgeInsets.only(top: 12.0f),
                            height: 56.0f,
                            decoration: new BoxDecoration(
                                border: Border.all(
                                    width: 1.0f,
                                    color: new Color(0xff979797)
                                ),
                                color: new Color(0xffffffff)
                            )
                        )
                    }
                )
            );
        }
    }
}