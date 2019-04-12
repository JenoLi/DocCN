using System.Collections.Generic;
using Unity.UIWidgets.painting;
using Unity.UIWidgets.rendering;
using Unity.UIWidgets.widgets;
using UnityEngine;
using Color = Unity.UIWidgets.ui.Color;

namespace DocCN.Components
{
    public partial class SearchBar : StatefulWidget
    {
        private class SearchBarState : State<SearchBar>
        {
            private FilterType _filterType;
            private TextEditingController _textEditingController;
            private FocusNode _focusNode;

            private static readonly BorderSide FilterBorderSide =
                new BorderSide(width: 2.0f, color: new Color(0xff424242));

            public override void initState()
            {
                base.initState();
                _filterType = FilterType.manual;
                _textEditingController = new TextEditingController();
                _focusNode = new FocusNode();
            }

            public override void dispose()
            {
                _focusNode.dispose();
                _textEditingController.dispose();
                base.dispose();
            }

            public override Widget build(BuildContext context)
            {
                return new Container(
                    height: Height,
                    padding: EdgeInsets.only(top: 8.0f, right: 48.0f, bottom: 8.0f, left: 48.0f),
                    color: new Color(0xff212121),
                    child: new Row(
                        crossAxisAlignment: CrossAxisAlignment.stretch,
                        children: new List<Widget>
                        {
                            new DropDown<FilterType>(
                                items: new[] {FilterType.manual, FilterType.scripting},
                                itemBuilder: item => new FilterItem(
                                    onTap: () =>
                                    {
                                        if (mounted)
                                        {
                                            setState(() => _filterType = item);
                                        }
                                    },
                                    text: item.Text()
                                ),
                                selectBuilder: () => new Container(
                                    width: 170.0f,
                                    decoration: new BoxDecoration(
                                        border: new Border(
                                            top: FilterBorderSide,
                                            left: FilterBorderSide,
                                            bottom: FilterBorderSide
                                        )
                                    ),
                                    child: new Row(
                                        mainAxisAlignment: MainAxisAlignment.center,
                                        children: new List<Widget>
                                        {
                                            new Text(
                                                "筛选：",
                                                style: new TextStyle(
                                                    color: new Color(0xffd8d8d8),
                                                    fontSize: 16f
                                                )
                                            ),
                                            new Text(
                                                _filterType.Text(),
                                                style: new TextStyle(
                                                    color: new Color(0xffffffff),
                                                    fontSize: 16f
                                                )
                                            ),
                                            new Icon(
                                                Style.Icons.MaterialArrowDropDown,
                                                color: new Color(0xffffffff),
                                                size: 24f
                                            )
                                        }
                                    )
                                )
                            ),
                            new Expanded(
                                child: new Container(
                                    color: new Color(0xff424242),
                                    padding: EdgeInsets.symmetric(horizontal: 24f),
                                    child: new Center(
                                        child: new EditableText(
                                            controller: _textEditingController,
                                            focusNode: _focusNode,
                                            style: new TextStyle(
                                                color: new Color(0xffffffff),
                                                fontSize: 16f,
                                                fontFamily: "PingFang"
                                            ),
                                            cursorColor: new Color(0xffff0000),
                                            onEditingComplete: () =>
                                            {
                                                _focusNode.unfocus();
                                                widget._onSearch?.Invoke(_textEditingController.value.text);
                                            }
                                        )
                                    )
                                )
                            ),
                            new Clickable(
                                onTap: () => widget._onSearch?.Invoke(_textEditingController.value.text),
                                child: new Container(
                                    width: 56.0f,
                                    color: new Color(0xff565656),
                                    child: new Center(
                                        child: new Icon(
                                            Style.Icons.MaterialSearch,
                                            color: new Color(0xffd8d8d8)
                                        )
                                    )
                                )
                            )
                        }
                    )
                );
            }
        }
    }
}