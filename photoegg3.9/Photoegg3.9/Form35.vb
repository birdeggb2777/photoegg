﻿Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices
Public Class Form35
    Dim r1(255) As Byte
    Dim r2(255) As Byte
    Dim g1(255) As Byte
    Dim g2(255) As Byte
    Dim t55 As Byte = 5
    Dim t66 As Byte = 5
    Dim t77 As Byte = 5
    Private Sub Form35_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = 2
        If Form1.語言ToolStripMenuItem.Text = "語言" Then
            Label1.Text = "密碼(六位數)"
            Button1.Text = "確定"
            Button3.Text = "加密"
            Button4.Text = "解密"
            Me.Text = "圖片加密程式"
        ElseIf Form1.語言ToolStripMenuItem.Text = "Language" Then
            Label1.Text = "Password (6 digits)"
            Button1.Text = "determine"
            Button3.Text = "encryption"
            Button4.Text = "Decryption"
            Me.Text = "Image encryption program"
        ElseIf Form1.語言ToolStripMenuItem.Text = "言語" Then
            Label1.Text = "パスワード（6桁）"
            Button1.Text = "決定します"
            Button3.Text = "暗号化"
            Button4.Text = "暗号解読"
            Me.Text = "画像暗号化プログラム"
        End If
        Button1.BackColor = Form1.BackColor
        Button4.BackColor = Form1.BackColor
        Button3.BackColor = Form1.BackColor
        Me.BackColor = Form1.BackColor
        Me.ForeColor = Form1.ForeColor
        PictureBox1.Image = Form1.PictureBox1.Image
        Dim a As New Bitmap(PictureBox1.Image)
        PictureBox1.Size = New Size(Form1.PictureBox1.Width, Form1.PictureBox1.Height)
        Me.WindowState = 2
        r1(0) = 110
        r1(1) = 121
        r1(2) = 220
        r1(3) = 233
        r1(4) = 195
        r1(5) = 97
        r1(6) = 59
        r1(7) = 80
        r1(8) = 239
        r1(9) = 41
        r1(10) = 237
        r1(11) = 112
        r1(12) = 183
        r1(13) = 130
        r1(14) = 182
        r1(15) = 24
        r1(16) = 39
        r1(17) = 15
        r1(18) = 49
        r1(19) = 107
        r1(20) = 203
        r1(21) = 77
        r1(22) = 98
        r1(23) = 109
        r1(24) = 99
        r1(25) = 73
        r1(26) = 44
        r1(27) = 206
        r1(28) = 94
        r1(29) = 212
        r1(30) = 118
        r1(31) = 249
        r1(32) = 245
        r1(33) = 150
        r1(34) = 225
        r1(35) = 111
        r1(36) = 179
        r1(37) = 145
        r1(38) = 189
        r1(39) = 103
        r1(40) = 69
        r1(41) = 224
        r1(42) = 42
        r1(43) = 156
        r1(44) = 136
        r1(45) = 168
        r1(46) = 199
        r1(47) = 223
        r1(48) = 194
        r1(49) = 211
        r1(50) = 6
        r1(51) = 123
        r1(52) = 74
        r1(53) = 192
        r1(54) = 48
        r1(55) = 141
        r1(56) = 76
        r1(57) = 247
        r1(58) = 124
        r1(59) = 43
        r1(60) = 35
        r1(61) = 178
        r1(62) = 198
        r1(63) = 78
        r1(64) = 120
        r1(65) = 148
        r1(66) = 91
        r1(67) = 4
        r1(68) = 23
        r1(69) = 117
        r1(70) = 170
        r1(71) = 131
        r1(72) = 215
        r1(73) = 205
        r1(74) = 1
        r1(75) = 151
        r1(76) = 101
        r1(77) = 52
        r1(78) = 248
        r1(79) = 181
        r1(80) = 219
        r1(81) = 25
        r1(82) = 57
        r1(83) = 116
        r1(84) = 185
        r1(85) = 67
        r1(86) = 209
        r1(87) = 102
        r1(88) = 157
        r1(89) = 213
        r1(90) = 207
        r1(91) = 153
        r1(92) = 90
        r1(93) = 63
        r1(94) = 184
        r1(95) = 58
        r1(96) = 60
        r1(97) = 208
        r1(98) = 85
        r1(99) = 147
        r1(100) = 175
        r1(101) = 34
        r1(102) = 236
        r1(103) = 201
        r1(104) = 169
        r1(105) = 167
        r1(106) = 64
        r1(107) = 100
        r1(108) = 126
        r1(109) = 119
        r1(110) = 191
        r1(111) = 17
        r1(112) = 84
        r1(113) = 166
        r1(114) = 137
        r1(115) = 172
        r1(116) = 70
        r1(117) = 227
        r1(118) = 135
        r1(119) = 171
        r1(120) = 0
        r1(121) = 255
        r1(122) = 122
        r1(123) = 54
        r1(124) = 228
        r1(125) = 50
        r1(126) = 68
        r1(127) = 95
        r1(128) = 230
        r1(129) = 20
        r1(130) = 38
        r1(131) = 36
        r1(132) = 31
        r1(133) = 115
        r1(134) = 19
        r1(135) = 186
        r1(136) = 139
        r1(137) = 251
        r1(138) = 252
        r1(139) = 188
        r1(140) = 13
        r1(141) = 132
        r1(142) = 217
        r1(143) = 40
        r1(144) = 53
        r1(145) = 88
        r1(146) = 108
        r1(147) = 2
        r1(148) = 83
        r1(149) = 240
        r1(150) = 12
        r1(151) = 146
        r1(152) = 210
        r1(153) = 32
        r1(154) = 162
        r1(155) = 200
        r1(156) = 204
        r1(157) = 33
        r1(158) = 22
        r1(159) = 246
        r1(160) = 21
        r1(161) = 160
        r1(162) = 140
        r1(163) = 37
        r1(164) = 197
        r1(165) = 18
        r1(166) = 125
        r1(167) = 152
        r1(168) = 232
        r1(169) = 164
        r1(170) = 26
        r1(171) = 173
        r1(172) = 79
        r1(173) = 134
        r1(174) = 187
        r1(175) = 93
        r1(176) = 226
        r1(177) = 29
        r1(178) = 10
        r1(179) = 250
        r1(180) = 27
        r1(181) = 92
        r1(182) = 196
        r1(183) = 177
        r1(184) = 193
        r1(185) = 216
        r1(186) = 30
        r1(187) = 96
        r1(188) = 142
        r1(189) = 180
        r1(190) = 8
        r1(191) = 238
        r1(192) = 176
        r1(193) = 218
        r1(194) = 222
        r1(195) = 51
        r1(196) = 89
        r1(197) = 138
        r1(198) = 9
        r1(199) = 243
        r1(200) = 71
        r1(201) = 104
        r1(202) = 47
        r1(203) = 62
        r1(204) = 105
        r1(205) = 159
        r1(206) = 45
        r1(207) = 149
        r1(208) = 127
        r1(209) = 28
        r1(210) = 114
        r1(211) = 235
        r1(212) = 106
        r1(213) = 75
        r1(214) = 128
        r1(215) = 241
        r1(216) = 56
        r1(217) = 165
        r1(218) = 234
        r1(219) = 14
        r1(220) = 16
        r1(221) = 143
        r1(222) = 5
        r1(223) = 253
        r1(224) = 254
        r1(225) = 87
        r1(226) = 82
        r1(227) = 144
        r1(228) = 158
        r1(229) = 113
        r1(230) = 72
        r1(231) = 86
        r1(232) = 55
        r1(233) = 46
        r1(234) = 244
        r1(235) = 155
        r1(236) = 229
        r1(237) = 242
        r1(238) = 3
        r1(239) = 190
        r1(240) = 161
        r1(241) = 61
        r1(242) = 65
        r1(243) = 11
        r1(244) = 163
        r1(245) = 231
        r1(246) = 129
        r1(247) = 174
        r1(248) = 154
        r1(249) = 221
        r1(250) = 81
        r1(251) = 214
        r1(252) = 7
        r1(253) = 66
        r1(254) = 133
        r1(255) = 202
        r2(110) = 0
        r2(121) = 1
        r2(220) = 2
        r2(233) = 3
        r2(195) = 4
        r2(97) = 5
        r2(59) = 6
        r2(80) = 7
        r2(239) = 8
        r2(41) = 9
        r2(237) = 10
        r2(112) = 11
        r2(183) = 12
        r2(130) = 13
        r2(182) = 14
        r2(24) = 15
        r2(39) = 16
        r2(15) = 17
        r2(49) = 18
        r2(107) = 19
        r2(203) = 20
        r2(77) = 21
        r2(98) = 22
        r2(109) = 23
        r2(99) = 24
        r2(73) = 25
        r2(44) = 26
        r2(206) = 27
        r2(94) = 28
        r2(212) = 29
        r2(118) = 30
        r2(249) = 31
        r2(245) = 32
        r2(150) = 33
        r2(225) = 34
        r2(111) = 35
        r2(179) = 36
        r2(145) = 37
        r2(189) = 38
        r2(103) = 39
        r2(69) = 40
        r2(224) = 41
        r2(42) = 42
        r2(156) = 43
        r2(136) = 44
        r2(168) = 45
        r2(199) = 46
        r2(223) = 47
        r2(194) = 48
        r2(211) = 49
        r2(6) = 50
        r2(123) = 51
        r2(74) = 52
        r2(192) = 53
        r2(48) = 54
        r2(141) = 55
        r2(76) = 56
        r2(247) = 57
        r2(124) = 58
        r2(43) = 59
        r2(35) = 60
        r2(178) = 61
        r2(198) = 62
        r2(78) = 63
        r2(120) = 64
        r2(148) = 65
        r2(91) = 66
        r2(4) = 67
        r2(23) = 68
        r2(117) = 69
        r2(170) = 70
        r2(131) = 71
        r2(215) = 72
        r2(205) = 73
        r2(1) = 74
        r2(151) = 75
        r2(101) = 76
        r2(52) = 77
        r2(248) = 78
        r2(181) = 79
        r2(219) = 80
        r2(25) = 81
        r2(57) = 82
        r2(116) = 83
        r2(185) = 84
        r2(67) = 85
        r2(209) = 86
        r2(102) = 87
        r2(157) = 88
        r2(213) = 89
        r2(207) = 90
        r2(153) = 91
        r2(90) = 92
        r2(63) = 93
        r2(184) = 94
        r2(58) = 95
        r2(60) = 96
        r2(208) = 97
        r2(85) = 98
        r2(147) = 99
        r2(175) = 100
        r2(34) = 101
        r2(236) = 102
        r2(201) = 103
        r2(169) = 104
        r2(167) = 105
        r2(64) = 106
        r2(100) = 107
        r2(126) = 108
        r2(119) = 109
        r2(191) = 110
        r2(17) = 111
        r2(84) = 112
        r2(166) = 113
        r2(137) = 114
        r2(172) = 115
        r2(70) = 116
        r2(227) = 117
        r2(135) = 118
        r2(171) = 119
        r2(0) = 120
        r2(255) = 121
        r2(122) = 122
        r2(54) = 123
        r2(228) = 124
        r2(50) = 125
        r2(68) = 126
        r2(95) = 127
        r2(230) = 128
        r2(20) = 129
        r2(38) = 130
        r2(36) = 131
        r2(31) = 132
        r2(115) = 133
        r2(19) = 134
        r2(186) = 135
        r2(139) = 136
        r2(251) = 137
        r2(252) = 138
        r2(188) = 139
        r2(13) = 140
        r2(132) = 141
        r2(217) = 142
        r2(40) = 143
        r2(53) = 144
        r2(88) = 145
        r2(108) = 146
        r2(2) = 147
        r2(83) = 148
        r2(240) = 149
        r2(12) = 150
        r2(146) = 151
        r2(210) = 152
        r2(32) = 153
        r2(162) = 154
        r2(200) = 155
        r2(204) = 156
        r2(33) = 157
        r2(22) = 158
        r2(246) = 159
        r2(21) = 160
        r2(160) = 161
        r2(140) = 162
        r2(37) = 163
        r2(197) = 164
        r2(18) = 165
        r2(125) = 166
        r2(152) = 167
        r2(232) = 168
        r2(164) = 169
        r2(26) = 170
        r2(173) = 171
        r2(79) = 172
        r2(134) = 173
        r2(187) = 174
        r2(93) = 175
        r2(226) = 176
        r2(29) = 177
        r2(10) = 178
        r2(250) = 179
        r2(27) = 180
        r2(92) = 181
        r2(196) = 182
        r2(177) = 183
        r2(193) = 184
        r2(216) = 185
        r2(30) = 186
        r2(96) = 187
        r2(142) = 188
        r2(180) = 189
        r2(8) = 190
        r2(238) = 191
        r2(176) = 192
        r2(218) = 193
        r2(222) = 194
        r2(51) = 195
        r2(89) = 196
        r2(138) = 197
        r2(9) = 198
        r2(243) = 199
        r2(71) = 200
        r2(104) = 201
        r2(47) = 202
        r2(62) = 203
        r2(105) = 204
        r2(159) = 205
        r2(45) = 206
        r2(149) = 207
        r2(127) = 208
        r2(28) = 209
        r2(114) = 210
        r2(235) = 211
        r2(106) = 212
        r2(75) = 213
        r2(128) = 214
        r2(241) = 215
        r2(56) = 216
        r2(165) = 217
        r2(234) = 218
        r2(14) = 219
        r2(16) = 220
        r2(143) = 221
        r2(5) = 222
        r2(253) = 223
        r2(254) = 224
        r2(87) = 225
        r2(82) = 226
        r2(144) = 227
        r2(158) = 228
        r2(113) = 229
        r2(72) = 230
        r2(86) = 231
        r2(55) = 232
        r2(46) = 233
        r2(244) = 234
        r2(155) = 235
        r2(229) = 236
        r2(242) = 237
        r2(3) = 238
        r2(190) = 239
        r2(161) = 240
        r2(61) = 241
        r2(65) = 242
        r2(11) = 243
        r2(163) = 244
        r2(231) = 245
        r2(129) = 246
        r2(174) = 247
        r2(154) = 248
        r2(221) = 249
        r2(81) = 250
        r2(214) = 251
        r2(7) = 252
        r2(66) = 253
        r2(133) = 254
        r2(202) = 255
        g1(0) = 202
        g1(1) = 133
        g1(2) = 66
        g1(3) = 7
        g1(4) = 214
        g1(5) = 81
        g1(6) = 221
        g1(7) = 154
        g1(8) = 174
        g1(9) = 129
        g1(10) = 231
        g1(11) = 163
        g1(12) = 11
        g1(13) = 65
        g1(14) = 61
        g1(15) = 161
        g1(16) = 190
        g1(17) = 3
        g1(18) = 242
        g1(19) = 229
        g1(20) = 155
        g1(21) = 244
        g1(22) = 46
        g1(23) = 55
        g1(24) = 86
        g1(25) = 72
        g1(26) = 113
        g1(27) = 158
        g1(28) = 144
        g1(29) = 82
        g1(30) = 87
        g1(31) = 254
        g1(32) = 253
        g1(33) = 5
        g1(34) = 143
        g1(35) = 16
        g1(36) = 14
        g1(37) = 234
        g1(38) = 165
        g1(39) = 56
        g1(40) = 241
        g1(41) = 128
        g1(42) = 75
        g1(43) = 106
        g1(44) = 235
        g1(45) = 114
        g1(46) = 28
        g1(47) = 127
        g1(48) = 149
        g1(49) = 45
        g1(50) = 159
        g1(51) = 105
        g1(52) = 62
        g1(53) = 47
        g1(54) = 104
        g1(55) = 71
        g1(56) = 243
        g1(57) = 9
        g1(58) = 138
        g1(59) = 89
        g1(60) = 51
        g1(61) = 222
        g1(62) = 218
        g1(63) = 176
        g1(64) = 238
        g1(65) = 8
        g1(66) = 180
        g1(67) = 142
        g1(68) = 96
        g1(69) = 30
        g1(70) = 216
        g1(71) = 193
        g1(72) = 177
        g1(73) = 196
        g1(74) = 92
        g1(75) = 27
        g1(76) = 250
        g1(77) = 10
        g1(78) = 29
        g1(79) = 226
        g1(80) = 93
        g1(81) = 187
        g1(82) = 134
        g1(83) = 79
        g1(84) = 173
        g1(85) = 26
        g1(86) = 164
        g1(87) = 232
        g1(88) = 152
        g1(89) = 125
        g1(90) = 18
        g1(91) = 197
        g1(92) = 37
        g1(93) = 140
        g1(94) = 160
        g1(95) = 21
        g1(96) = 246
        g1(97) = 22
        g1(98) = 33
        g1(99) = 204
        g1(100) = 200
        g1(101) = 162
        g1(102) = 32
        g1(103) = 210
        g1(104) = 146
        g1(105) = 12
        g1(106) = 240
        g1(107) = 83
        g1(108) = 2
        g1(109) = 108
        g1(110) = 88
        g1(111) = 53
        g1(112) = 40
        g1(113) = 217
        g1(114) = 132
        g1(115) = 13
        g1(116) = 188
        g1(117) = 252
        g1(118) = 251
        g1(119) = 139
        g1(120) = 186
        g1(121) = 19
        g1(122) = 115
        g1(123) = 31
        g1(124) = 36
        g1(125) = 38
        g1(126) = 20
        g1(127) = 230
        g1(128) = 95
        g1(129) = 68
        g1(130) = 50
        g1(131) = 228
        g1(132) = 54
        g1(133) = 122
        g1(134) = 255
        g1(135) = 0
        g1(136) = 171
        g1(137) = 135
        g1(138) = 227
        g1(139) = 70
        g1(140) = 172
        g1(141) = 137
        g1(142) = 166
        g1(143) = 84
        g1(144) = 17
        g1(145) = 191
        g1(146) = 119
        g1(147) = 126
        g1(148) = 100
        g1(149) = 64
        g1(150) = 167
        g1(151) = 169
        g1(152) = 201
        g1(153) = 236
        g1(154) = 34
        g1(155) = 175
        g1(156) = 147
        g1(157) = 85
        g1(158) = 208
        g1(159) = 60
        g1(160) = 58
        g1(161) = 184
        g1(162) = 63
        g1(163) = 90
        g1(164) = 153
        g1(165) = 207
        g1(166) = 213
        g1(167) = 157
        g1(168) = 102
        g1(169) = 209
        g1(170) = 67
        g1(171) = 185
        g1(172) = 116
        g1(173) = 57
        g1(174) = 25
        g1(175) = 219
        g1(176) = 181
        g1(177) = 248
        g1(178) = 52
        g1(179) = 101
        g1(180) = 151
        g1(181) = 1
        g1(182) = 205
        g1(183) = 215
        g1(184) = 131
        g1(185) = 170
        g1(186) = 117
        g1(187) = 23
        g1(188) = 4
        g1(189) = 91
        g1(190) = 148
        g1(191) = 120
        g1(192) = 78
        g1(193) = 198
        g1(194) = 178
        g1(195) = 35
        g1(196) = 43
        g1(197) = 124
        g1(198) = 247
        g1(199) = 76
        g1(200) = 141
        g1(201) = 48
        g1(202) = 192
        g1(203) = 74
        g1(204) = 123
        g1(205) = 6
        g1(206) = 211
        g1(207) = 194
        g1(208) = 223
        g1(209) = 199
        g1(210) = 168
        g1(211) = 136
        g1(212) = 156
        g1(213) = 42
        g1(214) = 224
        g1(215) = 69
        g1(216) = 103
        g1(217) = 189
        g1(218) = 145
        g1(219) = 179
        g1(220) = 111
        g1(221) = 225
        g1(222) = 150
        g1(223) = 245
        g1(224) = 249
        g1(225) = 118
        g1(226) = 212
        g1(227) = 94
        g1(228) = 206
        g1(229) = 44
        g1(230) = 73
        g1(231) = 99
        g1(232) = 109
        g1(233) = 98
        g1(234) = 77
        g1(235) = 203
        g1(236) = 107
        g1(237) = 49
        g1(238) = 15
        g1(239) = 39
        g1(240) = 24
        g1(241) = 182
        g1(242) = 130
        g1(243) = 183
        g1(244) = 112
        g1(245) = 237
        g1(246) = 41
        g1(247) = 239
        g1(248) = 80
        g1(249) = 59
        g1(250) = 97
        g1(251) = 195
        g1(252) = 233
        g1(253) = 220
        g1(254) = 121
        g1(255) = 110
        g2(202) = 0
        g2(133) = 1
        g2(66) = 2
        g2(7) = 3
        g2(214) = 4
        g2(81) = 5
        g2(221) = 6
        g2(154) = 7
        g2(174) = 8
        g2(129) = 9
        g2(231) = 10
        g2(163) = 11
        g2(11) = 12
        g2(65) = 13
        g2(61) = 14
        g2(161) = 15
        g2(190) = 16
        g2(3) = 17
        g2(242) = 18
        g2(229) = 19
        g2(155) = 20
        g2(244) = 21
        g2(46) = 22
        g2(55) = 23
        g2(86) = 24
        g2(72) = 25
        g2(113) = 26
        g2(158) = 27
        g2(144) = 28
        g2(82) = 29
        g2(87) = 30
        g2(254) = 31
        g2(253) = 32
        g2(5) = 33
        g2(143) = 34
        g2(16) = 35
        g2(14) = 36
        g2(234) = 37
        g2(165) = 38
        g2(56) = 39
        g2(241) = 40
        g2(128) = 41
        g2(75) = 42
        g2(106) = 43
        g2(235) = 44
        g2(114) = 45
        g2(28) = 46
        g2(127) = 47
        g2(149) = 48
        g2(45) = 49
        g2(159) = 50
        g2(105) = 51
        g2(62) = 52
        g2(47) = 53
        g2(104) = 54
        g2(71) = 55
        g2(243) = 56
        g2(9) = 57
        g2(138) = 58
        g2(89) = 59
        g2(51) = 60
        g2(222) = 61
        g2(218) = 62
        g2(176) = 63
        g2(238) = 64
        g2(8) = 65
        g2(180) = 66
        g2(142) = 67
        g2(96) = 68
        g2(30) = 69
        g2(216) = 70
        g2(193) = 71
        g2(177) = 72
        g2(196) = 73
        g2(92) = 74
        g2(27) = 75
        g2(250) = 76
        g2(10) = 77
        g2(29) = 78
        g2(226) = 79
        g2(93) = 80
        g2(187) = 81
        g2(134) = 82
        g2(79) = 83
        g2(173) = 84
        g2(26) = 85
        g2(164) = 86
        g2(232) = 87
        g2(152) = 88
        g2(125) = 89
        g2(18) = 90
        g2(197) = 91
        g2(37) = 92
        g2(140) = 93
        g2(160) = 94
        g2(21) = 95
        g2(246) = 96
        g2(22) = 97
        g2(33) = 98
        g2(204) = 99
        g2(200) = 100
        g2(162) = 101
        g2(32) = 102
        g2(210) = 103
        g2(146) = 104
        g2(12) = 105
        g2(240) = 106
        g2(83) = 107
        g2(2) = 108
        g2(108) = 109
        g2(88) = 110
        g2(53) = 111
        g2(40) = 112
        g2(217) = 113
        g2(132) = 114
        g2(13) = 115
        g2(188) = 116
        g2(252) = 117
        g2(251) = 118
        g2(139) = 119
        g2(186) = 120
        g2(19) = 121
        g2(115) = 122
        g2(31) = 123
        g2(36) = 124
        g2(38) = 125
        g2(20) = 126
        g2(230) = 127
        g2(95) = 128
        g2(68) = 129
        g2(50) = 130
        g2(228) = 131
        g2(54) = 132
        g2(122) = 133
        g2(255) = 134
        g2(0) = 135
        g2(171) = 136
        g2(135) = 137
        g2(227) = 138
        g2(70) = 139
        g2(172) = 140
        g2(137) = 141
        g2(166) = 142
        g2(84) = 143
        g2(17) = 144
        g2(191) = 145
        g2(119) = 146
        g2(126) = 147
        g2(100) = 148
        g2(64) = 149
        g2(167) = 150
        g2(169) = 151
        g2(201) = 152
        g2(236) = 153
        g2(34) = 154
        g2(175) = 155
        g2(147) = 156
        g2(85) = 157
        g2(208) = 158
        g2(60) = 159
        g2(58) = 160
        g2(184) = 161
        g2(63) = 162
        g2(90) = 163
        g2(153) = 164
        g2(207) = 165
        g2(213) = 166
        g2(157) = 167
        g2(102) = 168
        g2(209) = 169
        g2(67) = 170
        g2(185) = 171
        g2(116) = 172
        g2(57) = 173
        g2(25) = 174
        g2(219) = 175
        g2(181) = 176
        g2(248) = 177
        g2(52) = 178
        g2(101) = 179
        g2(151) = 180
        g2(1) = 181
        g2(205) = 182
        g2(215) = 183
        g2(131) = 184
        g2(170) = 185
        g2(117) = 186
        g2(23) = 187
        g2(4) = 188
        g2(91) = 189
        g2(148) = 190
        g2(120) = 191
        g2(78) = 192
        g2(198) = 193
        g2(178) = 194
        g2(35) = 195
        g2(43) = 196
        g2(124) = 197
        g2(247) = 198
        g2(76) = 199
        g2(141) = 200
        g2(48) = 201
        g2(192) = 202
        g2(74) = 203
        g2(123) = 204
        g2(6) = 205
        g2(211) = 206
        g2(194) = 207
        g2(223) = 208
        g2(199) = 209
        g2(168) = 210
        g2(136) = 211
        g2(156) = 212
        g2(42) = 213
        g2(224) = 214
        g2(69) = 215
        g2(103) = 216
        g2(189) = 217
        g2(145) = 218
        g2(179) = 219
        g2(111) = 220
        g2(225) = 221
        g2(150) = 222
        g2(245) = 223
        g2(249) = 224
        g2(118) = 225
        g2(212) = 226
        g2(94) = 227
        g2(206) = 228
        g2(44) = 229
        g2(73) = 230
        g2(99) = 231
        g2(109) = 232
        g2(98) = 233
        g2(77) = 234
        g2(203) = 235
        g2(107) = 236
        g2(49) = 237
        g2(15) = 238
        g2(39) = 239
        g2(24) = 240
        g2(182) = 241
        g2(130) = 242
        g2(183) = 243
        g2(112) = 244
        g2(237) = 245
        g2(41) = 246
        g2(239) = 247
        g2(80) = 248
        g2(59) = 249
        g2(97) = 250
        g2(195) = 251
        g2(233) = 252
        g2(220) = 253
        g2(121) = 254
        g2(110) = 255
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            Dim te As String = TextBox1.Text
            Dim t1 As Integer = Strings.Left(te, 1)
            Dim t2 As Integer = Strings.Mid(te, 2, 1)
            Dim t3 As Integer = Strings.Mid(te, 3, 1)
            Dim t5 As Integer = Strings.Mid(te, 4, 1)
            Dim t6 As Integer = Strings.Mid(te, 5, 1)
            Dim t7 As Integer = Strings.Mid(te, 6, 1)
            Dim t4 As Integer = Strings.Mid(te, 6)
            t66 = t6
            t77 = t7
            t55 = t5
            Dim start_time As Date = Now
            Dim Width As Integer, Height As Integer
            Dim mBitmap As Bitmap
            mBitmap = New Bitmap(PictureBox1.Image)
            For i = 1 To t1
                Try
                    Width = mBitmap.Width
                    Height = mBitmap.Height
                    Dim rect As New Rectangle(0, 0, Width, Height)
                    Dim bmpData As BitmapData = mBitmap.LockBits(rect, ImageLockMode.ReadWrite, mBitmap.PixelFormat)
                    Dim ptr As IntPtr = bmpData.Scan0
                    Dim bytes As Integer = bmpData.Stride * Height
                    With bmpData
                    End With
                    Dim Bpx As Byte = bmpData.Stride \ mBitmap.Width
                    Dim rgbValues(bytes - 1) As Byte
                    Marshal.Copy(ptr, rgbValues, 0, bytes)
                    For k As Integer = 0 To rgbValues.Length - Bpx Step Bpx
                        rgbValues(k) = r1(rgbValues(k))
                    Next
                    Marshal.Copy(rgbValues, 0, ptr, bytes) '
                    mBitmap.UnlockBits(bmpData)
                    Dim elapsed_time As TimeSpan = Now.Subtract(start_time)
                Catch ex As SystemException
                    MsgBox(ex.Message, MsgBoxStyle.Critical)
                End Try
            Next
            PictureBox1.Image = mBitmap
            For i = 1 To t2
                Try
                    Width = mBitmap.Width
                    Height = mBitmap.Height
                    Dim rect As New Rectangle(0, 0, Width, Height)
                    Dim bmpData As BitmapData = mBitmap.LockBits(rect, ImageLockMode.ReadWrite, mBitmap.PixelFormat)
                    Dim ptr As IntPtr = bmpData.Scan0
                    Dim bytes As Integer = bmpData.Stride * Height
                    With bmpData
                    End With
                    Dim Bpx As Byte = bmpData.Stride \ mBitmap.Width
                    Dim rgbValues(bytes - 1) As Byte
                    Marshal.Copy(ptr, rgbValues, 0, bytes)
                    For k As Integer = 0 To rgbValues.Length - Bpx Step Bpx
                        rgbValues(k + 1) = g1(rgbValues(k + 1))
                    Next
                    Marshal.Copy(rgbValues, 0, ptr, bytes) '
                    mBitmap.UnlockBits(bmpData)
                    Dim elapsed_time As TimeSpan = Now.Subtract(start_time)
                Catch ex As SystemException
                    MsgBox(ex.Message, MsgBoxStyle.Critical)
                End Try
            Next
            PictureBox1.Image = mBitmap
            For i = 1 To t3
                Try
                    Width = mBitmap.Width
                    Height = mBitmap.Height
                    Dim rect As New Rectangle(0, 0, Width, Height)
                    Dim bmpData As BitmapData = mBitmap.LockBits(rect, ImageLockMode.ReadWrite, mBitmap.PixelFormat)
                    Dim ptr As IntPtr = bmpData.Scan0
                    Dim bytes As Integer = bmpData.Stride * Height
                    With bmpData
                    End With
                    Dim Bpx As Byte = bmpData.Stride \ mBitmap.Width
                    Dim rgbValues(bytes - 1) As Byte
                    Marshal.Copy(ptr, rgbValues, 0, bytes)
                    For k As Integer = 0 To rgbValues.Length - Bpx Step Bpx
                        rgbValues(k + 2) = r1(rgbValues(k + 2))
                    Next
                    Marshal.Copy(rgbValues, 0, ptr, bytes) '
                    mBitmap.UnlockBits(bmpData)
                    Dim elapsed_time As TimeSpan = Now.Subtract(start_time)
                Catch ex As SystemException
                    MsgBox(ex.Message, MsgBoxStyle.Critical)
                End Try
            Next
            PictureBox1.Image = mBitmap
        Catch
            MsgBox("請輸入六位數的數字")
        End Try
        System.GC.Collect()
        PictureBox2.Image = PictureBox1.Image
        Try
            Dim te As String = TextBox1.Text
            Dim t1 As Integer = Strings.Left(te, 1)
            Dim t2 As Integer = Strings.Mid(te, 2, 1)
            Dim t3 As Integer = Strings.Mid(te, 3, 1)
            Dim t5 As Integer = Strings.Mid(te, 4, 1)
            Dim t6 As Integer = Strings.Mid(te, 5, 1)
            Dim t7 As Integer = Strings.Mid(te, 6, 1)
            Dim t4 As Integer = Strings.Mid(te, 6)
            t66 = t6
            t77 = t7
            t55 = t5
            Dim start_time As Date = Now
            Dim Width As Integer, Height As Integer
            Dim mBitmap As Bitmap
            Dim mBitmap2 As Bitmap
            mBitmap = New Bitmap(PictureBox1.Image)
            mBitmap2 = New Bitmap(PictureBox2.Image)
            Width = mBitmap.Width
            Height = mBitmap.Height
            Dim rect As New Rectangle(0, 0, Width, Height)
            Dim bmpData As BitmapData = mBitmap.LockBits(rect, ImageLockMode.ReadWrite, mBitmap.PixelFormat)
            Dim ptr As IntPtr = bmpData.Scan0
            Dim bytes As Integer = bmpData.Stride * Height
            With bmpData
            End With
            Dim rect2 As New Rectangle(0, 0, Width, Height)
            Dim bmpData2 As BitmapData = mBitmap2.LockBits(rect, ImageLockMode.ReadWrite, mBitmap2.PixelFormat)
            Dim ptr2 As IntPtr = bmpData2.Scan0
            Dim bytes2 As Integer = bmpData2.Stride * Height
            With bmpData2
            End With
            Dim Bpx As Byte = bmpData.Stride \ mBitmap.Width
            Dim Bpx2 As Byte = bmpData2.Stride \ mBitmap2.Width
            Dim rgbValues(bytes - 1) As Byte
            Marshal.Copy(ptr, rgbValues, 0, bytes)
            Dim rgbValues2(bytes - 1) As Byte
            Marshal.Copy(ptr2, rgbValues2, 0, bytes)
            Dim wi As Integer = mBitmap.Width
            Dim he As Integer = mBitmap.Height - t55
            If wi > he Then
                For i As Integer = 0 To wi - Bpx
                    For k As Integer = 0 To he * 4 - Bpx Step Bpx
                        rgbValues(k + i * he * 4) = rgbValues2(he * 4 + i * he * 4 - k)
                        If Bpx = 4 Then
                            rgbValues(k + i * he * 4 + 3) = rgbValues2(wi * 4 + i * he * 4 - k + 3)
                        End If
                    Next
                Next
                he = mBitmap.Height - t66
                For i As Integer = 0 To wi - Bpx
                    For k As Integer = 0 To he * 4 - Bpx Step Bpx
                        rgbValues(k + i * he * 4 + 1) = rgbValues2(he * 4 + i * he * 4 - k + 1)
                    Next
                Next
                he = mBitmap.Height - t77
                For i As Integer = 0 To wi - Bpx
                    For k As Integer = 0 To he * 4 - Bpx Step Bpx
                        rgbValues(k + i * he * 4 + 2) = rgbValues2(he * 4 + i * he * 4 - k + 2)
                    Next
                Next
            Else
            End If
            Marshal.Copy(rgbValues, 0, ptr, bytes) '
            mBitmap.UnlockBits(bmpData)
            mBitmap2.UnlockBits(bmpData2)
            Dim elapsed_time As TimeSpan = Now.Subtract(start_time)
            PictureBox1.Image = mBitmap
        Catch ex As SystemException
        End Try
        System.GC.Collect()
    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try
            Dim te As String = TextBox1.Text
            Dim t1 As Integer = Strings.Left(te, 1)
            Dim t2 As Integer = Strings.Mid(te, 2, 1)
            Dim t3 As Integer = Strings.Mid(te, 3, 1)
            Dim t5 As Integer = Strings.Mid(te, 4, 1)
            Dim t6 As Integer = Strings.Mid(te, 5, 1)
            Dim t7 As Integer = Strings.Mid(te, 6, 1)
            Dim t4 As Integer = Strings.Mid(te, 6)
            t66 = t6
            t77 = t7
            t55 = t5
            Dim start_time As Date = Now
            Dim Width As Integer, Height As Integer
            Dim mBitmap As Bitmap
            mBitmap = New Bitmap(PictureBox1.Image)
            For i = 1 To t1
                Try
                    Width = mBitmap.Width
                    Height = mBitmap.Height
                    Dim rect As New Rectangle(0, 0, Width, Height)
                    Dim bmpData As BitmapData = mBitmap.LockBits(rect, ImageLockMode.ReadWrite, mBitmap.PixelFormat)
                    Dim ptr As IntPtr = bmpData.Scan0
                    Dim bytes As Integer = bmpData.Stride * Height
                    With bmpData
                    End With
                    Dim Bpx As Byte = bmpData.Stride \ mBitmap.Width
                    Dim rgbValues(bytes - 1) As Byte
                    Marshal.Copy(ptr, rgbValues, 0, bytes)
                    For k As Integer = 0 To rgbValues.Length - Bpx Step Bpx
                        rgbValues(k) = r2(rgbValues(k))
                    Next
                    Marshal.Copy(rgbValues, 0, ptr, bytes) '
                    mBitmap.UnlockBits(bmpData)
                    Dim elapsed_time As TimeSpan = Now.Subtract(start_time)
                Catch ex As SystemException
                    MsgBox(ex.Message, MsgBoxStyle.Critical)
                End Try
            Next
            PictureBox1.Image = mBitmap
            For i = 1 To t2
                Try
                    Width = mBitmap.Width
                    Height = mBitmap.Height
                    Dim rect As New Rectangle(0, 0, Width, Height)
                    Dim bmpData As BitmapData = mBitmap.LockBits(rect, ImageLockMode.ReadWrite, mBitmap.PixelFormat)
                    Dim ptr As IntPtr = bmpData.Scan0
                    Dim bytes As Integer = bmpData.Stride * Height
                    With bmpData
                    End With
                    Dim Bpx As Byte = bmpData.Stride \ mBitmap.Width
                    Dim rgbValues(bytes - 1) As Byte
                    Marshal.Copy(ptr, rgbValues, 0, bytes)
                    For k As Integer = 0 To rgbValues.Length - Bpx Step Bpx
                        rgbValues(k + 1) = g2(rgbValues(k + 1))
                    Next
                    Marshal.Copy(rgbValues, 0, ptr, bytes) '
                    mBitmap.UnlockBits(bmpData)
                    Dim elapsed_time As TimeSpan = Now.Subtract(start_time)
                Catch ex As SystemException
                    MsgBox(ex.Message, MsgBoxStyle.Critical)
                End Try
            Next
            PictureBox1.Image = mBitmap
            For i = 1 To t3
                Try
                    Width = mBitmap.Width
                    Height = mBitmap.Height
                    Dim rect As New Rectangle(0, 0, Width, Height)
                    Dim bmpData As BitmapData = mBitmap.LockBits(rect, ImageLockMode.ReadWrite, mBitmap.PixelFormat)
                    Dim ptr As IntPtr = bmpData.Scan0
                    Dim bytes As Integer = bmpData.Stride * Height
                    With bmpData
                    End With
                    Dim Bpx As Byte = bmpData.Stride \ mBitmap.Width
                    Dim rgbValues(bytes - 1) As Byte
                    Marshal.Copy(ptr, rgbValues, 0, bytes)
                    For k As Integer = 0 To rgbValues.Length - Bpx Step Bpx
                        rgbValues(k + 2) = r2(rgbValues(k + 2))
                    Next
                    Marshal.Copy(rgbValues, 0, ptr, bytes) '
                    mBitmap.UnlockBits(bmpData)
                    Dim elapsed_time As TimeSpan = Now.Subtract(start_time)
                Catch ex As SystemException
                    MsgBox(ex.Message, MsgBoxStyle.Critical)
                End Try
            Next
            PictureBox1.Image = mBitmap
        Catch
            MsgBox("請輸入六位數的數字")
        End Try
        System.GC.Collect()
        PictureBox2.Image = PictureBox1.Image
        Try
            Dim te As String = TextBox1.Text
            Dim t1 As Integer = Strings.Left(te, 1)
            Dim t2 As Integer = Strings.Mid(te, 2, 1)
            Dim t3 As Integer = Strings.Mid(te, 3, 1)
            Dim t5 As Integer = Strings.Mid(te, 4, 1)
            Dim t6 As Integer = Strings.Mid(te, 5, 1)
            Dim t7 As Integer = Strings.Mid(te, 6, 1)
            Dim t4 As Integer = Strings.Mid(te, 6)
            t66 = t6
            t77 = t7
            t55 = t5
            Dim start_time As Date = Now
            Dim Width As Integer, Height As Integer
            Dim mBitmap As Bitmap
            Dim mBitmap2 As Bitmap
            mBitmap = New Bitmap(PictureBox1.Image)
            mBitmap2 = New Bitmap(PictureBox2.Image)
            Width = mBitmap.Width
            Height = mBitmap.Height
            Dim rect As New Rectangle(0, 0, Width, Height)
            Dim bmpData As BitmapData = mBitmap.LockBits(rect, ImageLockMode.ReadWrite, mBitmap.PixelFormat)
            Dim ptr As IntPtr = bmpData.Scan0
            Dim bytes As Integer = bmpData.Stride * Height
            With bmpData
            End With
            Dim rect2 As New Rectangle(0, 0, Width, Height)
            Dim bmpData2 As BitmapData = mBitmap2.LockBits(rect, ImageLockMode.ReadWrite, mBitmap2.PixelFormat)
            Dim ptr2 As IntPtr = bmpData2.Scan0
            Dim bytes2 As Integer = bmpData2.Stride * Height
            With bmpData2
            End With
            Dim Bpx As Byte = bmpData.Stride \ mBitmap.Width
            Dim Bpx2 As Byte = bmpData2.Stride \ mBitmap2.Width
            Dim rgbValues(bytes - 1) As Byte
            Marshal.Copy(ptr, rgbValues, 0, bytes)
            Dim rgbValues2(bytes - 1) As Byte
            Marshal.Copy(ptr2, rgbValues2, 0, bytes)
            Dim wi As Integer = mBitmap.Width
            Dim he As Integer = mBitmap.Height - t55
            If wi > he Then
                For i As Integer = 0 To wi - Bpx
                    For k As Integer = 0 To he * 4 - Bpx Step Bpx
                        rgbValues(he * 4 + i * he * 4 - k) = rgbValues2(k + i * he * 4)
                        If Bpx = 4 Then
                            rgbValues(he * 4 + i * he * 4 - k + 3) = rgbValues2(k + i * he * 4 + 3)
                        End If
                    Next
                Next
                he = mBitmap.Height - t66
                For i As Integer = 0 To wi - Bpx
                    For k As Integer = 0 To he * 4 - Bpx Step Bpx
                        rgbValues(he * 4 + i * he * 4 - k + 1) = rgbValues2(k + i * he * 4 + 1)
                        If Bpx = 4 Then
                            rgbValues(he * 4 + i * he * 4 - k + 3) = rgbValues2(k + i * he * 4 + 3)
                        End If
                    Next
                Next
                he = mBitmap.Height - t77
                For i As Integer = 0 To wi - Bpx
                    For k As Integer = 0 To he * 4 - Bpx Step Bpx
                        rgbValues(he * 4 + i * he * 4 - k + 2) = rgbValues2(k + i * he * 4 + 2)
                        If Bpx = 4 Then
                            rgbValues(he * 4 + i * he * 4 - k + 3) = rgbValues2(k + i * he * 4 + 3)
                        End If
                    Next
                Next
            Else
            End If
            Marshal.Copy(rgbValues, 0, ptr, bytes) '
            mBitmap.UnlockBits(bmpData)
            mBitmap2.UnlockBits(bmpData2)
            Dim elapsed_time As TimeSpan = Now.Subtract(start_time)
            PictureBox1.Image = mBitmap
        Catch ex As SystemException
        End Try
        System.GC.Collect()
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Form1.re2(Form1.re02) = Form1.PictureBox1.Image
        Form1.re02 += 1
        Form1.PictureBox1.Image = PictureBox1.Image
        Me.Close()
    End Sub
End Class