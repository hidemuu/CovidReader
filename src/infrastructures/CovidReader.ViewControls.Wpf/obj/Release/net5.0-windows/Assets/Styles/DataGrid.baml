   M S B A M L   `   `   `  ���� \  XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089  �� MergedDictionaries �� Source �� 
TargetType   BaseButtonStyle �� BasedOn �� TypeInTargetAssembly&     System.Windows.Controls.DataGrid �� 
ResourceId �� Property �� ValueG   ASystem.Windows.Controls.Primitives.DataGridColumnHeadersPresenter �� 
TargetType=   7System.Windows.Controls.Primitives.DataGridColumnHeader	 J� IsHitTestVisible  ColumnHeaderGripperStyle
 �� Padding  RowHeaderGripperStyle  ColumnFloatingHeaderStyle " ColumnHeaderDropSeparatorStyle  DataGridDropSeparator J� SnapsToDevicePixels)   #System.Windows.Controls.DataGridRow ��Name?   9System.Windows.Controls.Primitives.SelectiveScrollingGrid � ColumnDefinitions � RowDefinitions?   9System.Windows.Controls.Primitives.DataGridCellsPresenter   
ItemsPanelA   ;System.Windows.Controls.Primitives.DataGridDetailsPresenter   DetailsVisibility$   SelectiveScrollingOrientation �� RelativeSource �� AncestorType �� Path#    RowDetailsScrollingConverter �� 	Converter;   5System.Windows.Controls.SelectiveScrollingOrientation   Vertical �� ConverterParameter:   4System.Windows.Controls.Primitives.DataGridRowHeader!    HeadersVisibilityConverter7	   1System.Windows.Controls.DataGridHeadersVisibility
 	  Row �� Triggers P� Property P� Value  DataGridCellBackgroundHover*
   $System.Windows.Controls.DataGridCell  DataGridCellBackground  DataGridCellForeground �� Triggers 	 DataGridCellForegroundHover "
 DataGridCellBackgroundSelected " DataGridCellForegroundSelected  DataGridHeaderBackground  DataGridHeaderForeground  DefaultFontFamily  DefaultFontSize �Name  F�Name! �� Stretch" J� Opacity# J� RenderTransformOrigin$ n�Name% �� 
TargetName& �� Angle ! DataGridHeaderBackgroundHover ! DataGridHeaderForegroundHover # DataGridHeaderBackgroundPressed # DataGridHeaderForegroundPressed  DataGridGridLines' �� Orientation   BooleanToVisibilityConverter $  DataGridHeaderBackgroundSelected $  DataGridHeaderForegroundSelected  DataGridBackground  DataGridForeground(    SelectAllCommand
) 	  All* 	  Column+ ��Name, �� CanContentScroll- �� Orientation. �� ScrollableHeight/ � Maximum0 �� ViewportHeight1 �� ViewportSize*2 �� #ComputedVerticalScrollBarVisibility3 � Value4 �� Mode5 �� ScrollableWidth6 �� ViewportWidth,7 �� %ComputedHorizontalScrollBarVisibility�� F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      :x,http://schemas.microsoft.com/winfx/2006/xaml        �� $G A/CoronaReader.Windows.Infrastructure;component/Assets/Button.xaml?��� $K E/CoronaReader.Windows.Infrastructure;component/Assets/Converters.xaml?�%�  (��       "   $" DataGridSelectAllButtonStyle��)7   '  ?     &	 �     &	 2    &	 �    &	 r    '  �    '  d    '
  �    '  �    7  7  '      7  7  7  '   �    7  7  �� " ��8   .���  � ��
 ���� ��  � ��$ 0q��� "  .���  � �� �� "  .R�� .+�  $��PART_FillerColumnHeader��$	 False���� �� " n�.���  � ��$ 8����  � ��
 ���� ��  �@�Cursor$ SizeWE����  � �� �� " n�.R��� #
 z��#��z���� " n�.���  � ��$ 8����  � ��
 ���� ��  �@�Cursor$ SizeNS����  � �� �� " n�.R��� #
 z��#��z���� " ��.���  �@J�Opacity$	 0.6Q���  � ��$ 0q���  � �� �� " ��.R��� #��z��#��z��#
 z��#��z��._�� .+��� $��PART_VisualBrushCanvas��#��z���� " ��.���  � ��# �  ��  � �� �� " ��.R��� #��z��#��z��#��z��$
 True���� "  .���  � ��
 ���� ��  �@J�SnapsToDevicePixels$
 true����  �@=�ErrorTemplate Z� ��  �@ ValidationErrorTemplate �� .R��� $��2,0,0,0q�$��Center=����	#FFdc000c$��!����  � �� �� "  .R��� $ 
DGR_Border��#��z��#��z��#��z��$
 True��._�   �� $
��Auto ��� $��* � �� $��* ��� $
��Auto �.+�  $��1��#��z # z   $��1��$��1��#y�z  ��  �� "   $ AreRowDetailsFrozen�# Z # Z   $ Vertical=�$��2��y���  �� "   $ HeadersVisibility�# Z # Z  P�  �@J�IsMouseOver$
 True��. ��� # �   � ���� "  .���  � �� �� "  .R��� �� " 
 .���  � ��# �  ��  � ��# �  ��  � ��$ 0q���  � ��$	 5,1q���  � �� �� " 
 .R��� #��z��#��z��#��z��#
 z��$
 True��._��� # z  P�  �@J�IsMouseOver$
 True��. ���  � ��# �  ��  � ��# � 	 P�  �@
 
IsSelected$
 True��. ���  � ��# � 
 ��  � ��# �  �� "  .���  � ��# �  ��  � ��# �  ��  � ��$ 0q���  � ��$
 Bold"���  � ��# �  ��  � ��# �  ��  � ��$ 4,3,4,3q���  � ��$ Center=���  � ��$ Center=���  � �� �� "  .R�� .+��� #��z��#��z��#��z��#
 z��._�� $ containerGrid��$��5q� �� $��* ��� $
��Auto �.+��� $��0��#��z��# z #��z��F� $  	SortArrow��$��1��$��Center=�$��Center=�$��8��$��6��$��5,0,5,0q�$
! Fill=�$	" 0.5Q�#��z��$# 0.5,0.4&�$y�Hidden=�"����        �@B     � � @B 	n� $$ PART_LeftHeaderGripper��$
��Left=�8��  n� $$ PART_RightHeaderGripper��$��Right=�8��  P�  �@ SortDirection 	Ascending. ��� $% 	SortArrow�� � y�$ Visible=��� $% 	SortArrow�� � z� �� $	& 180Q�P�  �@ SortDirection 
Descending. ��� $% 	SortArrow�� � y�$ Visible=� P�  �@J�IsMouseOver$
 True��. ���  � ��# �  ��  � ��# �  P�  � ��$
 True��. ���  � ��# �  ��  � ��# �  �� "  .���  � ��# �  ��  � ��# �  ��  � ��# �  ��  � ��$ 0,0,0,1q���  � ��$ 16����  � �� �� "  .R�� .+��� #��z��#��z��#��z��#
 z��._��� $' 
Horizontal=�.+��� # z $��Center=��� $ false��y���  �� "  $ (Validation.HasError)�8   ����  �� "  $ ValidationErrorTemplate�n� $$ PART_TopHeaderGripper��$	��Top=�8�� n� $$ PART_BottomHeaderGripper��$��Bottom=�8��  P�  �@J�IsMouseOver$
 True��. ���  � ��# �  ��  � ��# �  P�  � ��$
 True��. ���  � ��# �  ��  � ��# �  P�  �@ IsRowSelected$
 True��. ���  � ��# �  ��  � ��# �  �� "   .���  � ��# �  ��  � ��# �  ��  � ��$ 0q���   �@  RowDetailsVisibilityMode$ VisibleWhenSelected=���   �@  HorizontalGridLinesBrush# �  ��  �@  VerticalGridLinesBrush# �  ��  �@  DragIndicatorStyle8   �� " �@  DropLocationIndicatorStyle8  ��  �@  GridLinesVisibility$ 
Horizontal=���  � ��$
 true����  �@��PanningMode$
 Both=���  �@��IsFlicksEnabled$ False����  � �� �� "   .R��� #��z��#��z��#��z��$
 True��#
 z��._��� $��DG_ScrollViewer��$|�false������ " ��.R��  �� $
��Auto ��� $��* ��� $
��Auto � �� $
��Auto ��� $��* ��� $
��Auto �.+��� #��Z( $|�false������  �� "   $  CellsPanelHorizontalOffset���C� *�� "   $" DataGridSelectAllButtonStyle��+y���  �� "   $ HeadersVisibility�# Z # Z)   $!��PART_ColumnHeadersPresenter��$��1��y���  �� "   $ HeadersVisibility�# Z # Z* �� $!+ PART_ScrollContentPresenter��$��1��$��2��#, z���� $��PART_VerticalScrollBar��$��1��$��2��$- Vertical=�#/ z. #1 z0 #y�z2 3 �� $ VerticalOffset� �� *TemplatedParent+$4 OneWay=�� $��2��$��1�� �� ����  �� "   $. (NonFrozenColumnsViewportHorizontalOffset��� $��* �.+��� $��PART_HorizontalScrollBar��$��1��$- 
Horizontal=�#/ z5 #1 z6 #y�z7 3 �� $ HorizontalOffset� �� *TemplatedParent+$4 OneWay=�.���� # z  P�  �@��
IsGrouping$
 true��. ���  � ��$ false��