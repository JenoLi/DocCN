using System.Collections.Generic;
using DocCN.Utility;
using Unity.UIWidgets.painting;
using Unity.UIWidgets.rendering;
using Unity.UIWidgets.widgets;
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
                var stylePack = widget._style.StylePack();
                var row = new Container(
                    height: 56,
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
                                    text: item.Text(),
                                    stylePack: widget._style.FilterItemStylePack()
                                ),
                                selectBuilder: () => new Container(
                                    width: 170.0f,
                                    decoration: stylePack.filterDecoration,
                                    child: new Row(
                                        mainAxisAlignment: MainAxisAlignment.center,
                                        children: new List<Widget>
                                        {
                                            new Text(
                                                "筛选：",
                                                style: new TextStyle(
                                                    color: stylePack.filterStrongColor,
                                                    fontSize: 16f
                                                )
                                            ),
                                            new Text(
                                                _filterType.Text(),
                                                style: new TextStyle(
                                                    color: stylePack.filterTextColor,
                                                    fontSize: 16f
                                                )
                                            ),
                                            new Icon(
                                                Style.Icons.MaterialArrowDropDown,
                                                color: stylePack.filterTextColor,
                                                size: 24f
                                            )
                                        }
                                    )
                                ),
                                overlayBorder: stylePack.filterItemsBorder
                            ),
                            new Expanded(
                                child: new Container(
                                    color: stylePack.searchInputBackgroundColor,
                                    padding: EdgeInsets.symmetric(horizontal: 24f),
                                    child: new Center(
                                        child: new EditableText(
                                            controller: _textEditingController,
                                            focusNode: _focusNode,
                                            style: new TextStyle(
                                                color: stylePack.searchInputColor,
                                                fontSize: 16f,
                                                fontFamily: "PingFang"
                                            ),
                                            cursorColor: stylePack.searchInputColor,
                                            onEditingComplete: () =>
                                            {
                                                _focusNode.unfocus();
                                                LocationUtil.Go($"/Search/{_textEditingController.value.text}");
                                            }
                                        )
                                    )
                                )
                            ),
                            new Clickable(
                                onTap: () => LocationUtil.Go($"/Search/{_textEditingController.value.text}"),
                                child: new Container(
                                    width: 56.0f,
                                    color: stylePack.searchIconBackgroundColor,
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
                if (widget._style == SearchBarStyle.embed)
                {
                    return row;
                }

                return new Container(
                    height: Height,
                    padding: EdgeInsets.only(top: 8.0f, right: 48.0f, bottom: 8.0f, left: 48.0f),
                    color: new Color(0xff212121),
                    child: row
                );
            }
        }
    }
}