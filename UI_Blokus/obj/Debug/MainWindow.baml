   M S B A M L   `   `   `  ����C  ?UI_Bloku, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:UI_Blokus	UI_Blokus  5   	   T PEmgu.CV.UI, Version=4.1.1.3497, Culture=neutral, PublicKeyToken=7281126722ab4438;,clr-namespace:Emgu.CV.UI;assembly=Emgu.CV.UI
Emgu.CV.UI 5   	   [ WSystem.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089Y@clr-namespace:System.Windows.Forms;assembly=System.Windows.FormsSystem.Windows.Forms 5   	       UI_Blokus.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:UI_Blokus     5   	   =emgu,clr-namespace:Emgu.CV.UI;assembly=Emgu.CV.UI     5   	   Owf@clr-namespace:System.Windows.Forms;assembly=System.Windows.Forms     5   	   -   5        $��12(�5
   	   $��Microsoft JhengHei)�5   	   
����·�  � Icon$  /Icon/Bloku.ico��5   	    � WindowStartupLocation$ CenterScreen=�5   	    � Title$ 德國圍棋��5   	   $��650.0��6   $��1080.0��6%    � 	Resources 5         buttonHover �� 
TargetType �� Property �� Value �� 
TargetType ��Name	 �� CornerRadius
 �� Triggers P� Property P� Value �� 
TargetName��%  &	        �� 5   
   " ��6$   .�5      ��  � �� �#8a8c8e6+   �� 5       � ��
 �   �6+   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $ border��6!   #��z��61   $��3q�6[   
���   �$	 3��6�   ._�5      �� $��Center=�6/   $��Center=�6L   5      
 5      P� 5       � �� . . �5   "   �� $ border��6)    � ��$ 5q�6X   5      P� 5       � �� . . �5    "   ��  � �� �#d3d7d46?   5!      5#      5%      5&      5'      .��5)      � -   5        .+�5*   
   �� 
��� ���._�5+      ��  �� Orientation$ Vertical=�6   $��Center=�60   .+�5,      �� $ 
Horizontal=�6   $��Center=�66   .+�5-         UI_Blokus.TwentyBox  -   5          Name$ TwentyBox_Board��5-   &   �� 5.      $ Vertical=�6!   .+�5/      �� 
��� E��$��
10,10,10,5q�69    �� Padding$ 5q�6V   ._�50      �� $ Vertical=�6)   $��Center=�6@   .+�51   "   �� $��系統資訊��6(   $��Center=�67   �� 52   "   -   5         ��Name$ RichTextBox_SystemLog��52   .   
�������$��Center=�6`    �� 
IsReadOnly . $	��380��6�   $	��200��6�   53      54      �� 55      
��� E��$��	10,5,10,5q�69   $ 5q�6U   ._�56      �� -   5         ��Name$ TabControl_Player��56   )    57   "   ��%V   '��       �� 58   &   " ��6,   .�59   *   ��  � ��$ Center=�6P   5:   '   5;   #   .@�5<   "   �� $��藍方��6*   $	��100��66   .��5=   &   � .+�5>   *      UI_Blokus.TwemtyOnePiece  -   5          Name$ TwemtyOnePiece_Blue��5>   ?   5?   '   5@   #   �� 5A   "   $��綠方��6*   $	��100��66   .��5B   &   � .+�5C   *     -   5        $ TwemtyOnePiece_Green��5C   ?   5D   '   5E   #   �� 5F   "   $��紅方��6*   $	��100��66   .��5G   &   � .+�5H   *     -   5        $ TwemtyOnePiece_Red��5H   ?   5I   '   5J   #   �� 5K   "   $��黃方��6*   $	��100��66   .��5L   &   � .+�5M   *     -	   5        $ TwemtyOnePiece_Yellow��5M   ?   5N   '   5O   #   5P      5Q      �� 5R      
��� E��$��
10,5,10,10q�69   $ 5q�6V   $��90��6b   ._�5S      �� $ 
Horizontal=�6)   $��Center=�6B   .+�5T   "   �� $��30��6)   $	��105��65   ._�5U   &   �� -
   5         ��Name$ Btn_NewGame��5U   -   $��30��6B   $��75��6N   ��5V   *   �� 5W   .   $ 
Horizontal=�69   .+�5X   2   �� $��重新��6<   5Y   /   5[   '   5\   #   �� 5]   "   $��30��6)   $	��105��65   ._�5^   &   �� -   5        $ Btn_EndGame��5^   -   $��30��6B   $��75��6N   ��5_   *   �� 5`   .   $ 
Horizontal=�69   .+�5a   2   �� $��結算��6<   5b   /   5d   '   5e   #   5f      5g      5h      5i      5j      5k      5l      5m      