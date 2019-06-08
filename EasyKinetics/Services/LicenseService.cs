/**
   EasyKinetics (tools for analyses of enzymatic solutions)
   Copyright 2018-2019 by Gabriele Morabito<bioinformaticgears@gmail.com>
  
   This file is part of EasyKinetics application.
   
   EasyKinetics is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License 
   as published by the Free Software Foundation, either version 3 of the License, or any later version.
   
   EasyKinetics is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty 
   of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
 
   You should have received a copy of the GNU General Public License along with this program.
   If not, see <http://www.gnu.org/licenses/> .

   license GPL-3.0-or-later
 */

/* LICENSE LAYOUT MODULE
   This module organizes the license text in 40 lines long pages:
   - identifying the requested page
   - loading page content
   - returning the page to the request submitter
*/

using System;
using System.ComponentModel;
using Windows.UI.Xaml.Controls;


namespace EasyKinetics.Services
{
    public static class LicenseServices
    {

        /*
            procedure extracting the page of the license required by the user
        */
        public static string GetLicensePage(int page_no)
        {
            if (page_no == 1)
            {
                string row_001 = "                    GNU GENERAL PUBLIC LICENSE";
                string row_002 = "                       Version 3, 29 June 2007";
                string row_003 = "";
                string row_004 = " Copyright (C) 2007 Free Software Foundation, Inc. <https://fsf.org/>";
                string row_005 = " Everyone is permitted to copy and distribute verbatim copies";
                string row_006 = "of this license document, but changing it is not allowed.";
                string row_007 = "";
                string row_008 = "                            Preamble";
                string row_009 = "";
                string row_010 = "  The GNU General Public License is a free, copyleft license for";
                string row_011 = "software and other kinds of works.";
                string row_012 = "";
                string row_013 = "  The licenses for most software and other practical works are designed";
                string row_014 = "to take away your freedom to share and change the works.  By contrast,";
                string row_015 = "the GNU General Public License is intended to guarantee your freedom to";
                string row_016 = "share and change all versions of a program--to make sure it remains free";
                string row_017 = "software for all its users.  We, the Free Software Foundation, use the";
                string row_018 = "GNU General Public License for most of our software; it applies also to";
                string row_019 = "any other work released this way by its authors.  You can apply it to";
                string row_020 = "your programs, too.";
                string row_021 = "";
                string row_022 = "  When we speak of free software, we are referring to freedom, not";
                string row_023 = "price.  Our General Public Licenses are designed to make sure that you";
                string row_024 = "have the freedom to distribute copies of free software (and charge for";
                string row_025 = "them if you wish), that you receive source code or can get it if you";
                string row_026 = "want it, that you can change the software or use pieces of it in new";
                string row_027 = "free programs, and that you know you can do these things.";
                string row_028 = "";
                string row_029 = "  To protect your rights, we need to prevent others from denying you";
                string row_030 = "these rights or asking you to surrender the rights.  Therefore, you have";
                string row_031 = "certain responsibilities if you distribute copies of the software, or if";
                string row_032 = "you modify it: responsibilities to respect the freedom of others.";
                string row_033 = "";
                string row_034 = "  For example, if you distribute copies of such a program, whether";
                string row_035 = "gratis or for a fee, you must pass on to the recipients the same";
                string row_036 = "freedoms that you received.  You must make sure that they, too, receive";
                string row_037 = "or can get the source code.  And you must show them these terms so they";
                string row_038 = "know their rights.";
                string row_039 = "";
                string row_040 = "  Developers that use the GNU GPL protect your rights with two steps:";

                string block_01 = String.Concat(row_001, "\n", row_002, "\n", row_003, "\n", row_004, "\n", row_005, "\n", row_006, "\n", row_007, "\n", row_008, "\n", row_009, "\n", row_010, "\n");
                string block_02 = String.Concat(row_011, "\n", row_012, "\n", row_013, "\n", row_014, "\n", row_015, "\n", row_016, "\n", row_017, "\n", row_018, "\n", row_019, "\n", row_020, "\n");
                string block_03 = String.Concat(row_021, "\n", row_022, "\n", row_023, "\n", row_024, "\n", row_025, "\n", row_026, "\n", row_027, "\n", row_028, "\n", row_029, "\n", row_030, "\n");
                string block_04 = String.Concat(row_031, "\n", row_032, "\n", row_033, "\n", row_034, "\n", row_035, "\n", row_036, "\n", row_037, "\n", row_038, "\n", row_039, "\n", row_040);

                string page_01 = String.Concat(block_01, block_02, block_03, block_04);

                return page_01;
            }
            else if (page_no == 2)
            {
                string row_041 = "(1) assert copyright on the software, and (2) offer you this License";
                string row_042 = "giving you legal permission to copy, distribute and/or modify it.";
                string row_043 = "";
                string row_044 = "  For the developers' and authors' protection, the GPL clearly explains";
                string row_045 = "that there is no warranty for this free software.  For both users' and";
                string row_046 = "authors' sake, the GPL requires that modified versions be marked as";
                string row_047 = "changed, so that their problems will not be attributed erroneously to";
                string row_048 = "authors of previous versions.";
                string row_049 = "";
                string row_050 = "  Some devices are designed to deny users access to install or run";
                string row_051 = "modified versions of the software inside them, although the manufacturer";
                string row_052 = "can do so.  This is fundamentally incompatible with the aim of";
                string row_053 = "protecting users' freedom to change the software.  The systematic";
                string row_054 = "pattern of such abuse occurs in the area of products for individuals to";
                string row_055 = "use, which is precisely where it is most unacceptable.  Therefore, we";
                string row_056 = "have designed this version of the GPL to prohibit the practice for those";
                string row_057 = "products.  If such problems arise substantially in other domains, we";
                string row_058 = "stand ready to extend this provision to those domains in future versions";
                string row_059 = "of the GPL, as needed to protect the freedom of users.";
                string row_060 = "";
                string row_061 = "  Finally, every program is threatened constantly by software patents.";
                string row_062 = "States should not allow patents to restrict development and use of";
                string row_063 = "software on general-purpose computers, but in those that do, we wish to";
                string row_064 = "avoid the special danger that patents applied to a free program could";
                string row_065 = "make it effectively proprietary.  To prevent this, the GPL assures that";
                string row_066 = "patents cannot be used to render the program non-free.";
                string row_067 = "";
                string row_068 = "  The precise terms and conditions for copying, distribution and";
                string row_069 = "modification follow.";
                string row_070 = "";
                string row_071 = "                       TERMS AND CONDITIONS";
                string row_072 = "";
                string row_073 = "  0. Definitions.";
                string row_074 = "";
                string row_075 = "  \"This License\" refers to version 3 of the GNU General Public License.";
                string row_076 = "";
                string row_077 = "  \"Copyright\" also means copyright-like laws that apply to other kinds of";
                string row_078 = "works, such as semiconductor masks.";
                string row_079 = "";
                string row_080 = "  \"The Program\" refers to any copyrightable work licensed under this";

                string block_05 = String.Concat(row_041, "\n", row_042, "\n", row_043, "\n", row_044, "\n", row_045, "\n", row_046, "\n", row_047, "\n", row_048, "\n", row_049, "\n", row_050, "\n");
                string block_06 = String.Concat(row_051, "\n", row_052, "\n", row_053, "\n", row_054, "\n", row_055, "\n", row_056, "\n", row_057, "\n", row_058, "\n", row_059, "\n", row_060, "\n");
                string block_07 = String.Concat(row_061, "\n", row_062, "\n", row_063, "\n", row_064, "\n", row_065, "\n", row_066, "\n", row_067, "\n", row_068, "\n", row_069, "\n", row_070, "\n");
                string block_08 = String.Concat(row_071, "\n", row_072, "\n", row_073, "\n", row_074, "\n", row_075, "\n", row_076, "\n", row_077, "\n", row_078, "\n", row_079, "\n", row_080);

                string page_02 = String.Concat(block_05, block_06, block_07, block_08);

                return page_02;
            }
            else if (page_no == 3)
            {
                string row_081 = "License.  Each licensee is addressed as \"you\".  \"Licensees\" and";
                string row_082 = "\"recipients\" may be individuals or organizations.";
                string row_083 = "";
                string row_084 = "  To \"modify\" a work means to copy from or adapt all or part of the work";
                string row_085 = "in a fashion requiring copyright permission, other than the making of an";
                string row_086 = "exact copy.  The resulting work is called a \"modified version\" of the";
                string row_087 = "earlier work or a work \"based on\" the earlier work.";
                string row_088 = "";
                string row_089 = "  A \"covered work\" means either the unmodified Program or a work based";
                string row_090 = "on the Program.";
                string row_091 = "";
                string row_092 = "  To \"propagate\" a work means to do anything with it that, without";
                string row_093 = "permission, would make you directly or secondarily liable for";
                string row_094 = "infringement under applicable copyright law, except executing it on a";
                string row_095 = "computer or modifying a private copy.  Propagation includes copying,";
                string row_096 = "distribution (with or without modification), making available to the";
                string row_097 = "public, and in some countries other activities as well.";
                string row_098 = "";
                string row_099 = "  To \"convey\" a work means any kind of propagation that enables other";
                string row_100 = "parties to make or receive copies.  Mere interaction with a user through";
                string row_101 = "a computer network, with no transfer of a copy, is not conveying.";
                string row_102 = "";
                string row_103 = "  An interactive user interface displays \"Appropriate Legal Notices\"";
                string row_104 = "to the extent that it includes a convenient and prominently visible";
                string row_105 = "feature that (1) displays an appropriate copyright notice, and (2)";
                string row_106 = "tells the user that there is no warranty for the work (except to the";
                string row_107 = "extent that warranties are provided), that licensees may convey the";
                string row_108 = "work under this License, and how to view a copy of this License.  If";
                string row_109 = "the interface presents a list of user commands or options, such as a";
                string row_110 = "menu, a prominent item in the list meets this criterion.";
                string row_111 = "";
                string row_112 = "  1. Source Code.";
                string row_113 = "";
                string row_114 = "  The \"source code\" for a work means the preferred form of the work";
                string row_115 = "for making modifications to it.  \"Object code\" means any non-source";
                string row_116 = "form of a work.";
                string row_117 = "";
                string row_118 = "  A \"Standard Interface\" means an interface that either is an official";
                string row_119 = "standard defined by a recognized standards body, or, in the case of";
                string row_120 = "interfaces specified for a particular programming language, one that";

                string block_09 = String.Concat(row_081, "\n", row_082, "\n", row_083, "\n", row_084, "\n", row_085, "\n", row_086, "\n", row_087, "\n", row_088, "\n", row_089, "\n", row_090, "\n");
                string block_10 = String.Concat(row_091, "\n", row_092, "\n", row_093, "\n", row_094, "\n", row_095, "\n", row_096, "\n", row_097, "\n", row_098, "\n", row_099, "\n", row_100, "\n");
                string block_11 = String.Concat(row_101, "\n", row_102, "\n", row_103, "\n", row_104, "\n", row_105, "\n", row_106, "\n", row_107, "\n", row_108, "\n", row_109, "\n", row_110, "\n");
                string block_12 = String.Concat(row_111, "\n", row_112, "\n", row_113, "\n", row_114, "\n", row_115, "\n", row_116, "\n", row_117, "\n", row_118, "\n", row_119, "\n", row_120);

                string page_03 = String.Concat(block_09, block_10, block_11, block_12);

                return page_03;
            }
            else if (page_no == 4)
            {
                string row_121 = "is widely used among developers working in that language.";
                string row_122 = "";
                string row_123 = "  The \"System Libraries\" of an executable work include anything, other";
                string row_124 = "than the work as a whole, that (a) is included in the normal form of";
                string row_125 = "packaging a Major Component, but which is not part of that Major";
                string row_126 = "Component, and (b) serves only to enable use of the work with that";
                string row_127 = "Major Component, or to implement a Standard Interface for which an";
                string row_128 = "implementation is available to the public in source code form.  A";
                string row_129 = "\"Major Component\", in this context, means a major essential component";
                string row_130 = "(kernel, window system, and so on) of the specific operating system";
                string row_131 = "(if any) on which the executable work runs, or a compiler used to";
                string row_132 = "produce the work, or an object code interpreter used to run it.";
                string row_133 = "";
                string row_134 = "  The \"Corresponding Source\" for a work in object code form means all";
                string row_135 = "the source code needed to generate, install, and (for an executable";
                string row_136 = "work) run the object code and to modify the work, including scripts to";
                string row_137 = "control those activities.  However, it does not include the work's";
                string row_138 = "System Libraries, or general-purpose tools or generally available free";
                string row_139 = "programs which are used unmodified in performing those activities but";
                string row_140 = "which are not part of the work.  For example, Corresponding Source";
                string row_141 = "includes interface definition files associated with source files for";
                string row_142 = "the work, and the source code for shared libraries and dynamically";
                string row_143 = "linked subprograms that the work is specifically designed to require,";
                string row_144 = "such as by intimate data communication or control flow between those";
                string row_145 = "subprograms and other parts of the work.";
                string row_146 = "";
                string row_147 = "  The Corresponding Source need not include anything that users";
                string row_148 = "can regenerate automatically from other parts of the Corresponding";
                string row_149 = "Source.";
                string row_150 = "";
                string row_151 = "  The Corresponding Source for a work in source code form is that";
                string row_152 = "same work.";
                string row_153 = "";
                string row_154 = "  2. Basic Permissions.";
                string row_155 = "";
                string row_156 = "  All rights granted under this License are granted for the term of";
                string row_157 = "copyright on the Program, and are irrevocable provided the stated";
                string row_158 = "conditions are met.  This License explicitly affirms your unlimited";
                string row_159 = "permission to run the unmodified Program.  The output from running a";
                string row_160 = "covered work is covered by this License only if the output, given its";

                string block_13 = String.Concat(row_121, "\n", row_122, "\n", row_123, "\n", row_124, "\n", row_125, "\n", row_126, "\n", row_127, "\n", row_128, "\n", row_129, "\n", row_130, "\n");
                string block_14 = String.Concat(row_131, "\n", row_132, "\n", row_133, "\n", row_134, "\n", row_135, "\n", row_136, "\n", row_137, "\n", row_138, "\n", row_139, "\n", row_140, "\n");
                string block_15 = String.Concat(row_141, "\n", row_142, "\n", row_143, "\n", row_144, "\n", row_145, "\n", row_146, "\n", row_147, "\n", row_148, "\n", row_149, "\n", row_150, "\n");
                string block_16 = String.Concat(row_151, "\n", row_152, "\n", row_153, "\n", row_154, "\n", row_155, "\n", row_156, "\n", row_157, "\n", row_158, "\n", row_159, "\n", row_160);

                string page_04 = String.Concat(block_13, block_14, block_15, block_16);

                return page_04;
            }
            else if (page_no == 5)
            {
                string row_161 = "content, constitutes a covered work.  This License acknowledges your";
                string row_162 = "rights of fair use or other equivalent, as provided by copyright law.";
                string row_163 = "";
                string row_164 = "  You may make, run and propagate covered works that you do not";
                string row_165 = "convey, without conditions so long as your license otherwise remains";
                string row_166 = "in force.  You may convey covered works to others for the sole purpose";
                string row_167 = "of having them make modifications exclusively for you, or provide you";
                string row_168 = "with facilities for running those works, provided that you comply with";
                string row_169 = "the terms of this License in conveying all material for which you do";
                string row_170 = "not control copyright.  Those thus making or running the covered works";
                string row_171 = "for you must do so exclusively on your behalf, under your direction";
                string row_172 = "and control, on terms that prohibit them from making any copies of";
                string row_173 = "your copyrighted material outside their relationship with you.";
                string row_174 = "";
                string row_175 = "  Conveying under any other circumstances is permitted solely under";
                string row_176 = "the conditions stated below.  Sublicensing is not allowed; section 10";
                string row_177 = "makes it unnecessary.";
                string row_178 = "";
                string row_179 = "  3. Protecting Users' Legal Rights From Anti-Circumvention Law.";
                string row_180 = "";
                string row_181 = "  No covered work shall be deemed part of an effective technological";
                string row_182 = "measure under any applicable law fulfilling obligations under article";
                string row_183 = "11 of the WIPO copyright treaty adopted on 20 December 1996, or";
                string row_184 = "similar laws prohibiting or restricting circumvention of such";
                string row_185 = "measures.";
                string row_186 = "";
                string row_187 = "  When you convey a covered work, you waive any legal power to forbid";
                string row_188 = "circumvention of technological measures to the extent such circumvention";
                string row_189 = "is effected by exercising rights under this License with respect to";
                string row_190 = "the covered work, and you disclaim any intention to limit operation or";
                string row_191 = "modification of the work as a means of enforcing, against the work's";
                string row_192 = "users, your or third parties' legal rights to forbid circumvention of";
                string row_193 = "technological measures.";
                string row_194 = "";
                string row_195 = "  4. Conveying Verbatim Copies.";
                string row_196 = "";
                string row_197 = "  You may convey verbatim copies of the Program's source code as you";
                string row_198 = "receive it, in any medium, provided that you conspicuously and";
                string row_199 = "appropriately publish on each copy an appropriate copyright notice;";
                string row_200 = "keep intact all notices stating that this License and any";

                string block_17 = String.Concat(row_161, "\n", row_162, "\n", row_163, "\n", row_164, "\n", row_165, "\n", row_166, "\n", row_167, "\n", row_168, "\n", row_169, "\n", row_170, "\n");
                string block_18 = String.Concat(row_171, "\n", row_172, "\n", row_173, "\n", row_174, "\n", row_175, "\n", row_176, "\n", row_177, "\n", row_178, "\n", row_179, "\n", row_180, "\n");
                string block_19 = String.Concat(row_181, "\n", row_182, "\n", row_183, "\n", row_184, "\n", row_185, "\n", row_186, "\n", row_187, "\n", row_188, "\n", row_189, "\n", row_190, "\n");
                string block_20 = String.Concat(row_191, "\n", row_192, "\n", row_193, "\n", row_194, "\n", row_195, "\n", row_196, "\n", row_197, "\n", row_198, "\n", row_199, "\n", row_200);

                string page_05 = String.Concat(block_17, block_18, block_19, block_20);

                return page_05;
            }
            else if (page_no == 6)
            {
                string row_201 = "non-permissive terms added in accord with section 7 apply to the code;";
                string row_202 = "keep intact all notices of the absence of any warranty; and give all";
                string row_203 = "recipients a copy of this License along with the Program.";
                string row_204 = "";
                string row_205 = "  You may charge any price or no price for each copy that you convey,";
                string row_206 = "and you may offer support or warranty protection for a fee.";
                string row_207 = "";
                string row_208 = "  5. Conveying Modified Source Versions.";
                string row_209 = "";
                string row_210 = "  You may convey a work based on the Program, or the modifications to";
                string row_211 = "produce it from the Program, in the form of source code under the";
                string row_212 = "terms of section 4, provided that you also meet all of these conditions:";
                string row_213 = "";
                string row_214 = "    a) The work must carry prominent notices stating that you modified";
                string row_215 = "    it, and giving a relevant date.";
                string row_216 = "";
                string row_217 = "    b) The work must carry prominent notices stating that it is";
                string row_218 = "    released under this License and any conditions added under section";
                string row_219 = "    7.  This requirement modifies the requirement in section 4 to";
                string row_220 = "    \"keep intact all notices\".";
                string row_221 = "";
                string row_222 = "    c) You must license the entire work, as a whole, under this";
                string row_223 = "    License to anyone who comes into possession of a copy.  This";
                string row_224 = "    License will therefore apply, along with any applicable section 7";
                string row_225 = "    additional terms, to the whole of the work, and all its parts,";
                string row_226 = "    regardless of how they are packaged.  This License gives no";
                string row_227 = "    permission to license the work in any other way, but it does not";
                string row_228 = "    invalidate such permission if you have separately received it.";
                string row_229 = "";
                string row_230 = "    d) If the work has interactive user interfaces, each must display";
                string row_231 = "    Appropriate Legal Notices; however, if the Program has interactive";
                string row_232 = "    interfaces that do not display Appropriate Legal Notices, your";
                string row_233 = "    work need not make them do so.";
                string row_234 = "";
                string row_235 = "  A compilation of a covered work with other separate and independent";
                string row_236 = "works, which are not by their nature extensions of the covered work,";
                string row_237 = "and which are not combined with it such as to form a larger program,";
                string row_238 = "in or on a volume of a storage or distribution medium, is called an";
                string row_239 = "\"aggregate\" if the compilation and its resulting copyright are not";
                string row_240 = "used to limit the access or legal rights of the compilation's users";

                string block_21 = String.Concat(row_201, "\n", row_202, "\n", row_203, "\n", row_204, "\n", row_205, "\n", row_206, "\n", row_207, "\n", row_208, "\n", row_209, "\n", row_210, "\n");
                string block_22 = String.Concat(row_211, "\n", row_212, "\n", row_213, "\n", row_214, "\n", row_215, "\n", row_216, "\n", row_217, "\n", row_218, "\n", row_219, "\n", row_220, "\n");
                string block_23 = String.Concat(row_221, "\n", row_222, "\n", row_223, "\n", row_224, "\n", row_225, "\n", row_226, "\n", row_227, "\n", row_228, "\n", row_229, "\n", row_230, "\n");
                string block_24 = String.Concat(row_231, "\n", row_232, "\n", row_233, "\n", row_234, "\n", row_235, "\n", row_236, "\n", row_237, "\n", row_238, "\n", row_239, "\n", row_240);

                string page_06 = String.Concat(block_21, block_22, block_23, block_24);

                return page_06;
            }
            else if (page_no == 7)
            {
                string row_241 = "beyond what the individual works permit.  Inclusion of a covered work";
                string row_242 = "in an aggregate does not cause this License to apply to the other";
                string row_243 = "parts of the aggregate.";
                string row_244 = "";
                string row_245 = "  6. Conveying Non-Source Forms.";
                string row_246 = "";
                string row_247 = "  You may convey a covered work in object code form under the terms";
                string row_248 = "of sections 4 and 5, provided that you also convey the";
                string row_249 = "machine-readable Corresponding Source under the terms of this License,";
                string row_250 = "in one of these ways:";
                string row_251 = "";
                string row_252 = "    a) Convey the object code in, or embodied in, a physical product";
                string row_253 = "    (including a physical distribution medium), accompanied by the";
                string row_254 = "    Corresponding Source fixed on a durable physical medium";
                string row_255 = "    customarily used for software interchange.";
                string row_256 = "";
                string row_257 = "    b) Convey the object code in, or embodied in, a physical product";
                string row_258 = "    (including a physical distribution medium), accompanied by a";
                string row_259 = "    written offer, valid for at least three years and valid for as";
                string row_260 = "    long as you offer spare parts or customer support for that product";
                string row_261 = "    model, to give anyone who possesses the object code either (1) a";
                string row_262 = "    copy of the Corresponding Source for all the software in the";
                string row_263 = "    product that is covered by this License, on a durable physical";
                string row_264 = "    medium customarily used for software interchange, for a price no";
                string row_265 = "    more than your reasonable cost of physically performing this";
                string row_266 = "    conveying of source, or (2) access to copy the";
                string row_267 = "    Corresponding Source from a network server at no charge.";
                string row_268 = "";
                string row_269 = "    c) Convey individual copies of the object code with a copy of the";
                string row_270 = "    written offer to provide the Corresponding Source.  This";
                string row_271 = "    alternative is allowed only occasionally and noncommercially, and";
                string row_272 = "    only if you received the object code with such an offer, in accord";
                string row_273 = "    with subsection 6b.";
                string row_274 = "";
                string row_275 = "    d) Convey the object code by offering access from a designated";
                string row_276 = "    place (gratis or for a charge), and offer equivalent access to the";
                string row_277 = "    Corresponding Source in the same way through the same place at no";
                string row_278 = "    further charge.  You need not require recipients to copy the";
                string row_279 = "    Corresponding Source along with the object code.  If the place to";
                string row_280 = "    copy the object code is a network server, the Corresponding Source";

                string block_25 = String.Concat(row_241, "\n", row_242, "\n", row_243, "\n", row_244, "\n", row_245, "\n", row_246, "\n", row_247, "\n", row_248, "\n", row_249, "\n", row_250, "\n");
                string block_26 = String.Concat(row_251, "\n", row_252, "\n", row_253, "\n", row_254, "\n", row_255, "\n", row_256, "\n", row_257, "\n", row_258, "\n", row_259, "\n", row_260, "\n");
                string block_27 = String.Concat(row_261, "\n", row_262, "\n", row_263, "\n", row_264, "\n", row_265, "\n", row_266, "\n", row_267, "\n", row_268, "\n", row_269, "\n", row_270, "\n");
                string block_28 = String.Concat(row_271, "\n", row_272, "\n", row_273, "\n", row_274, "\n", row_275, "\n", row_276, "\n", row_277, "\n", row_278, "\n", row_279, "\n", row_280);

                string page_07 = String.Concat(block_25, block_26, block_27, block_28);

                return page_07;
            }
            else if (page_no == 8)
            {
                string row_281 = "    may be on a different server (operated by you or a third party)";
                string row_282 = "    that supports equivalent copying facilities, provided you maintain";
                string row_283 = "    clear directions next to the object code saying where to find the";
                string row_284 = "    Corresponding Source.  Regardless of what server hosts the";
                string row_285 = "    Corresponding Source, you remain obligated to ensure that it is";
                string row_286 = "    available for as long as needed to satisfy these requirements.";
                string row_287 = "";
                string row_288 = "    e) Convey the object code using peer-to-peer transmission, provided";
                string row_289 = "    you inform other peers where the object code and Corresponding";
                string row_290 = "    Source of the work are being offered to the general public at no";
                string row_291 = "    charge under subsection 6d.";
                string row_292 = "";
                string row_293 = "  A separable portion of the object code, whose source code is excluded";
                string row_294 = "from the Corresponding Source as a System Library, need not be";
                string row_295 = "included in conveying the object code work.";
                string row_296 = "";
                string row_297 = "  A \"User Product\" is either (1) a \"consumer product\", which means any";
                string row_298 = "tangible personal property which is normally used for personal, family,";
                string row_299 = "or household purposes, or (2) anything designed or sold for incorporation";
                string row_300 = "into a dwelling.  In determining whether a product is a consumer product,";
                string row_301 = "doubtful cases shall be resolved in favor of coverage.  For a particular";
                string row_302 = "product received by a particular user, \"normally used\" refers to a";
                string row_303 = "typical or common use of that class of product, regardless of the status";
                string row_304 = "of the particular user or of the way in which the particular user";
                string row_305 = "actually uses, or expects or is expected to use, the product.  A product";
                string row_306 = "is a consumer product regardless of whether the product has substantial";
                string row_307 = "commercial, industrial or non-consumer uses, unless such uses represent";
                string row_308 = "the only significant mode of use of the product.";
                string row_309 = "";
                string row_310 = "  \"Installation Information\" for a User Product means any methods,";
                string row_311 = "procedures, authorization keys, or other information required to install";
                string row_312 = "and execute modified versions of a covered work in that User Product from";
                string row_313 = "a modified version of its Corresponding Source.  The information must";
                string row_314 = "suffice to ensure that the continued functioning of the modified object";
                string row_315 = "code is in no case prevented or interfered with solely because";
                string row_316 = "modification has been made.";
                string row_317 = "";
                string row_318 = "  If you convey an object code work under this section in, or with, or";
                string row_319 = "specifically for use in, a User Product, and the conveying occurs as";
                string row_320 = "part of a transaction in which the right of possession and use of the";

                string block_29 = String.Concat(row_281, "\n", row_282, "\n", row_283, "\n", row_284, "\n", row_285, "\n", row_286, "\n", row_287, "\n", row_288, "\n", row_289, "\n", row_290, "\n");
                string block_30 = String.Concat(row_291, "\n", row_292, "\n", row_293, "\n", row_294, "\n", row_295, "\n", row_296, "\n", row_297, "\n", row_298, "\n", row_299, "\n", row_300, "\n");
                string block_31 = String.Concat(row_301, "\n", row_302, "\n", row_303, "\n", row_304, "\n", row_305, "\n", row_306, "\n", row_307, "\n", row_308, "\n", row_309, "\n", row_310, "\n");
                string block_32 = String.Concat(row_311, "\n", row_312, "\n", row_313, "\n", row_314, "\n", row_315, "\n", row_316, "\n", row_317, "\n", row_318, "\n", row_319, "\n", row_320);

                string page_08 = String.Concat(block_29, block_30, block_31, block_32);

                return page_08;
            }
            else if (page_no == 9)
            {
                string row_321 = "User Product is transferred to the recipient in perpetuity or for a";
                string row_322 = "fixed term (regardless of how the transaction is characterized), the";
                string row_323 = "Corresponding Source conveyed under this section must be accompanied";
                string row_324 = "by the Installation Information.  But this requirement does not apply";
                string row_325 = "if neither you nor any third party retains the ability to install";
                string row_326 = "modified object code on the User Product (for example, the work has";
                string row_327 = "been installed in ROM).";
                string row_328 = "";
                string row_329 = "  The requirement to provide Installation Information does not include a";
                string row_330 = "requirement to continue to provide support service, warranty, or updates";
                string row_331 = "for a work that has been modified or installed by the recipient, or for";
                string row_332 = "the User Product in which it has been modified or installed.  Access to a";
                string row_333 = "network may be denied when the modification itself materially and";
                string row_334 = "adversely affects the operation of the network or violates the rules and";
                string row_335 = "protocols for communication across the network.";
                string row_336 = "";
                string row_337 = "  Corresponding Source conveyed, and Installation Information provided,";
                string row_338 = "in accord with this section must be in a format that is publicly";
                string row_339 = "documented (and with an implementation available to the public in";
                string row_340 = "source code form), and must require no special password or key for";
                string row_341 = "unpacking, reading or copying.";
                string row_342 = "";
                string row_343 = "  7. Additional Terms.";
                string row_344 = "";
                string row_345 = "  \"Additional permissions\" are terms that supplement the terms of this";
                string row_346 = "License by making exceptions from one or more of its conditions.";
                string row_347 = "Additional permissions that are applicable to the entire Program shall";
                string row_348 = "be treated as though they were included in this License, to the extent";
                string row_349 = "that they are valid under applicable law.  If additional permissions";
                string row_350 = "apply only to part of the Program, that part may be used separately";
                string row_351 = "under those permissions, but the entire Program remains governed by";
                string row_352 = "this License without regard to the additional permissions.";
                string row_353 = "";
                string row_354 = "  When you convey a copy of a covered work, you may at your option";
                string row_355 = "remove any additional permissions from that copy, or from any part of";
                string row_356 = "it.  (Additional permissions may be written to require their own";
                string row_357 = "removal in certain cases when you modify the work.)  You may place";
                string row_358 = "additional permissions on material, added by you to a covered work,";
                string row_359 = "for which you have or can give appropriate copyright permission.";
                string row_360 = "";

                string block_33 = String.Concat(row_321, "\n", row_322, "\n", row_323, "\n", row_324, "\n", row_325, "\n", row_326, "\n", row_327, "\n", row_328, "\n", row_329, "\n", row_330, "\n");
                string block_34 = String.Concat(row_331, "\n", row_332, "\n", row_333, "\n", row_334, "\n", row_335, "\n", row_336, "\n", row_337, "\n", row_338, "\n", row_339, "\n", row_340, "\n");
                string block_35 = String.Concat(row_341, "\n", row_342, "\n", row_343, "\n", row_344, "\n", row_345, "\n", row_346, "\n", row_347, "\n", row_348, "\n", row_349, "\n", row_350, "\n");
                string block_36 = String.Concat(row_351, "\n", row_352, "\n", row_353, "\n", row_354, "\n", row_355, "\n", row_356, "\n", row_357, "\n", row_358, "\n", row_359, "\n", row_360);

                string page_09 = String.Concat(block_33, block_34, block_35, block_36);

                return page_09;
            }
            else if (page_no == 10)
            {
                string row_361 = "  Notwithstanding any other provision of this License, for material you";
                string row_362 = "add to a covered work, you may (if authorized by the copyright holders of";
                string row_363 = "that material) supplement the terms of this License with terms:";
                string row_364 = "";
                string row_365 = "    a) Disclaiming warranty or limiting liability differently from the";
                string row_366 = "    terms of sections 15 and 16 of this License; or";
                string row_367 = "";
                string row_368 = "    b) Requiring preservation of specified reasonable legal notices or";
                string row_369 = "    author attributions in that material or in the Appropriate Legal";
                string row_370 = "    Notices displayed by works containing it; or";
                string row_371 = "";
                string row_372 = "    c) Prohibiting misrepresentation of the origin of that material, or";
                string row_373 = "    requiring that modified versions of such material be marked in";
                string row_374 = "    reasonable ways as different from the original version; or";
                string row_375 = "";
                string row_376 = "    d) Limiting the use for publicity purposes of names of licensors or";
                string row_377 = "    authors of the material; or";
                string row_378 = "";
                string row_379 = "    e) Declining to grant rights under trademark law for use of some";
                string row_380 = "    trade names, trademarks, or service marks; or";
                string row_381 = "";
                string row_382 = "    f) Requiring indemnification of licensors and authors of that";
                string row_383 = "    material by anyone who conveys the material (or modified versions of";
                string row_384 = "    it) with contractual assumptions of liability to the recipient, for";
                string row_385 = "    any liability that these contractual assumptions directly impose on";
                string row_386 = "    those licensors and authors.";
                string row_387 = "";
                string row_388 = "  All other non-permissive additional terms are considered \"further";
                string row_389 = "restrictions\" within the meaning of section 10.If the Program as you";
                string row_390 = "received it, or any part of it, contains a notice stating that it is";
                string row_391 = "governed by this License along with a term that is a further";
                string row_392 = "restriction, you may remove that term.  If a license document contains";
                string row_393 = "a further restriction but permits relicensing or conveying under this";
                string row_394 = "License, you may add to a covered work material governed by the terms";
                string row_395 = "of that license document, provided that the further restriction does";
                string row_396 = "not survive such relicensing or conveying.";
                string row_397 = "";
                string row_398 = "  If you add terms to a covered work in accord with this section, you";
                string row_399 = "must place, in the relevant source files, a statement of the";
                string row_400 = "additional terms that apply to those files, or a notice indicating";

                string block_37 = String.Concat(row_361, "\n", row_362, "\n", row_363, "\n", row_364, "\n", row_365, "\n", row_366, "\n", row_367, "\n", row_368, "\n", row_369, "\n", row_370, "\n");
                string block_38 = String.Concat(row_371, "\n", row_372, "\n", row_373, "\n", row_374, "\n", row_375, "\n", row_376, "\n", row_377, "\n", row_378, "\n", row_379, "\n", row_380, "\n");
                string block_39 = String.Concat(row_381, "\n", row_382, "\n", row_383, "\n", row_384, "\n", row_385, "\n", row_386, "\n", row_387, "\n", row_388, "\n", row_389, "\n", row_390, "\n");
                string block_40 = String.Concat(row_391, "\n", row_392, "\n", row_393, "\n", row_394, "\n", row_395, "\n", row_396, "\n", row_397, "\n", row_398, "\n", row_399, "\n", row_400);

                string page_10 = String.Concat(block_37, block_38, block_39, block_40);

                return page_10;
            }
            else if (page_no == 11)
            {
                string row_401 = "where to find the applicable terms.";
                string row_402 = "";
                string row_403 = "  Additional terms, permissive or non-permissive, may be stated in the";
                string row_404 = "form of a separately written license, or stated as exceptions;";
                string row_405 = "the above requirements apply either way.";
                string row_406 = "";
                string row_407 = "  8. Termination.";
                string row_408 = "";
                string row_409 = "  You may not propagate or modify a covered work except as expressly";
                string row_410 = "provided under this License.  Any attempt otherwise to propagate or";
                string row_411 = "modify it is void, and will automatically terminate your rights under";
                string row_412 = "this License (including any patent licenses granted under the third";
                string row_413 = "paragraph of section 11).";
                string row_414 = "";
                string row_415 = "  However, if you cease all violation of this License, then your";
                string row_416 = "license from a particular copyright holder is reinstated (a)";
                string row_417 = "provisionally, unless and until the copyright holder explicitly and";
                string row_418 = "finally terminates your license, and (b) permanently, if the copyright";
                string row_419 = "holder fails to notify you of the violation by some reasonable means";
                string row_420 = "prior to 60 days after the cessation.";
                string row_421 = "";
                string row_422 = "  Moreover, your license from a particular copyright holder is";
                string row_423 = "reinstated permanently if the copyright holder notifies you of the";
                string row_424 = "violation by some reasonable means, this is the first time you have";
                string row_425 = "received notice of violation of this License (for any work) from that";
                string row_426 = "copyright holder, and you cure the violation prior to 30 days after";
                string row_427 = "your receipt of the notice.";
                string row_428 = "";
                string row_429 = "  Termination of your rights under this section does not terminate the";
                string row_430 = "licenses of parties who have received copies or rights from you under";
                string row_431 = "this License.  If your rights have been terminated and not permanently";
                string row_432 = "reinstated, you do not qualify to receive new licenses for the same";
                string row_433 = "material under section 10.";
                string row_434 = "";
                string row_435 = "  9. Acceptance Not Required for Having Copies.";
                string row_436 = "";
                string row_437 = "  You are not required to accept this License in order to receive or";
                string row_438 = "run a copy of the Program.  Ancillary propagation of a covered work";
                string row_439 = "occurring solely as a consequence of using peer-to-peer transmission";
                string row_440 = "to receive a copy likewise does not require acceptance.  However,";

                string block_41 = String.Concat(row_401, "\n", row_402, "\n", row_403, "\n", row_404, "\n", row_405, "\n", row_406, "\n", row_407, "\n", row_408, "\n", row_409, "\n", row_410, "\n");
                string block_42 = String.Concat(row_411, "\n", row_412, "\n", row_413, "\n", row_414, "\n", row_415, "\n", row_416, "\n", row_417, "\n", row_418, "\n", row_419, "\n", row_420, "\n");
                string block_43 = String.Concat(row_421, "\n", row_422, "\n", row_423, "\n", row_424, "\n", row_425, "\n", row_426, "\n", row_427, "\n", row_428, "\n", row_429, "\n", row_430, "\n");
                string block_44 = String.Concat(row_431, "\n", row_432, "\n", row_433, "\n", row_434, "\n", row_435, "\n", row_436, "\n", row_437, "\n", row_438, "\n", row_439, "\n", row_440);

                string page_11 = String.Concat(block_41, block_42, block_43, block_44);

                return page_11;
            }
            else if (page_no == 12)
            {
                string row_441 = "nothing other than this License grants you permission to propagate or";
                string row_442 = "modify any covered work.  These actions infringe copyright if you do";
                string row_443 = "not accept this License.  Therefore, by modifying or propagating a";
                string row_444 = "covered work, you indicate your acceptance of this License to do so.";
                string row_445 = "";
                string row_446 = "  10. Automatic Licensing of Downstream Recipients.";
                string row_447 = "";
                string row_448 = "  Each time you convey a covered work, the recipient automatically";
                string row_449 = "receives a license from the original licensors, to run, modify and";
                string row_450 = "propagate that work, subject to this License.  You are not responsible";
                string row_451 = "for enforcing compliance by third parties with this License.";
                string row_452 = "";
                string row_453 = "  An \"entity transaction\" is a transaction transferring control of an";
                string row_454 = "organization, or substantially all assets of one, or subdividing an";
                string row_455 = "organization, or merging organizations.  If propagation of a covered";
                string row_456 = "work results from an entity transaction, each party to that";
                string row_457 = "transaction who receives a copy of the work also receives whatever";
                string row_458 = "licenses to the work the party's predecessor in interest had or could";
                string row_459 = "give under the previous paragraph, plus a right to possession of the";
                string row_460 = "Corresponding Source of the work from the predecessor in interest, if";
                string row_461 = "the predecessor has it or can get it with reasonable efforts.";
                string row_462 = "";
                string row_463 = "  You may not impose any further restrictions on the exercise of the";
                string row_464 = "rights granted or affirmed under this License.  For example, you may";
                string row_465 = "not impose a license fee, royalty, or other charge for exercise of";
                string row_466 = "rights granted under this License, and you may not initiate litigation";
                string row_467 = "(including a cross-claim or counterclaim in a lawsuit) alleging that";
                string row_468 = "any patent claim is infringed by making, using, selling, offering for";
                string row_469 = "sale, or importing the Program or any portion of it.";
                string row_470 = "";
                string row_471 = "  11. Patents.";
                string row_472 = "";
                string row_473 = "  A \"contributor\" is a copyright holder who authorizes use under this";
                string row_474 = "License of the Program or a work on which the Program is based.  The";
                string row_475 = "work thus licensed is called the contributor's \"contributor version\".";
                string row_476 = "";
                string row_477 = "  A contributor's \"essential patent claims\" are all patent claims";
                string row_478 = "owned or controlled by the contributor, whether already acquired or";
                string row_479 = "hereafter acquired, that would be infringed by some manner, permitted";
                string row_480 = "by this License, of making, using, or selling its contributor version,";

                string block_45 = String.Concat(row_441, "\n", row_442, "\n", row_443, "\n", row_444, "\n", row_445, "\n", row_446, "\n", row_447, "\n", row_448, "\n", row_449, "\n", row_450, "\n");
                string block_46 = String.Concat(row_451, "\n", row_452, "\n", row_453, "\n", row_454, "\n", row_455, "\n", row_456, "\n", row_457, "\n", row_458, "\n", row_459, "\n", row_460, "\n");
                string block_47 = String.Concat(row_461, "\n", row_462, "\n", row_463, "\n", row_464, "\n", row_465, "\n", row_466, "\n", row_467, "\n", row_468, "\n", row_469, "\n", row_470, "\n");
                string block_48 = String.Concat(row_471, "\n", row_472, "\n", row_473, "\n", row_474, "\n", row_475, "\n", row_476, "\n", row_477, "\n", row_478, "\n", row_479, "\n", row_480);

                string page_12 = String.Concat(block_45, block_46, block_47, block_48);

                return page_12;
            }
            else if (page_no == 13)
            {
                string row_481 = "but do not include claims that would be infringed only as a";
                string row_482 = "consequence of further modification of the contributor version.  For";
                string row_483 = "purposes of this definition, \"control\" includes the right to grant";
                string row_484 = "patent sublicenses in a manner consistent with the requirements of";
                string row_485 = "this License.";
                string row_486 = "";
                string row_487 = "  Each contributor grants you a non-exclusive, worldwide, royalty-free";
                string row_488 = "patent license under the contributor's essential patent claims, to";
                string row_489 = "make, use, sell, offer for sale, import and otherwise run, modify and";
                string row_490 = "propagate the contents of its contributor version.";
                string row_491 = "";
                string row_492 = "  In the following three paragraphs, a \"patent license\" is any express";
                string row_493 = "agreement or commitment, however denominated, not to enforce a patent";
                string row_494 = "(such as an express permission to practice a patent or covenant not to";
                string row_495 = "sue for patent infringement).  To \"grant\" such a patent license to a";
                string row_496 = "party means to make such an agreement or commitment not to enforce a";
                string row_497 = "patent against the party.";
                string row_498 = "";
                string row_499 = "  If you convey a covered work, knowingly relying on a patent license,";
                string row_500 = "and the Corresponding Source of the work is not available for anyone";
                string row_501 = "to copy, free of charge and under the terms of this License, through a";
                string row_502 = "publicly available network server or other readily accessible means,";
                string row_503 = "then you must either (1) cause the Corresponding Source to be so";
                string row_504 = "available, or (2) arrange to deprive yourself of the benefit of the";
                string row_505 = "patent license for this particular work, or (3) arrange, in a manner";
                string row_506 = "consistent with the requirements of this License, to extend the patent";
                string row_507 = "license to downstream recipients.  \"Knowingly relying\" means you have";
                string row_508 = "actual knowledge that, but for the patent license, your conveying the";
                string row_509 = "covered work in a country, or your recipient's use of the covered work";
                string row_510 = "in a country, would infringe one or more identifiable patents in that";
                string row_511 = "country that you have reason to believe are valid.";
                string row_512 = "";
                string row_513 = "  If, pursuant to or in connection with a single transaction or";
                string row_514 = "arrangement, you convey, or propagate by procuring conveyance of, a";
                string row_515 = "covered work, and grant a patent license to some of the parties";
                string row_516 = "receiving the covered work authorizing them to use, propagate, modify";
                string row_517 = "or convey a specific copy of the covered work, then the patent license";
                string row_518 = "you grant is automatically extended to all recipients of the covered";
                string row_519 = "work and works based on it.";
                string row_520 = "";

                string block_49 = String.Concat(row_481, "\n", row_482, "\n", row_483, "\n", row_484, "\n", row_485, "\n", row_486, "\n", row_487, "\n", row_488, "\n", row_489, "\n", row_490, "\n");
                string block_50 = String.Concat(row_491, "\n", row_492, "\n", row_493, "\n", row_494, "\n", row_495, "\n", row_496, "\n", row_497, "\n", row_498, "\n", row_499, "\n", row_500, "\n");
                string block_51 = String.Concat(row_501, "\n", row_502, "\n", row_503, "\n", row_504, "\n", row_505, "\n", row_506, "\n", row_507, "\n", row_508, "\n", row_509, "\n", row_510, "\n");
                string block_52 = String.Concat(row_511, "\n", row_512, "\n", row_513, "\n", row_514, "\n", row_515, "\n", row_516, "\n", row_517, "\n", row_518, "\n", row_519, "\n", row_520);

                string page_13 = String.Concat(block_49, block_50, block_51, block_52);

                return page_13;
            }
            else if (page_no == 14)
            {
                string row_521 = "  A patent license is \"discriminatory\" if it does not include within";
                string row_522 = "the scope of its coverage, prohibits the exercise of, or is";
                string row_523 = "conditioned on the non-exercise of one or more of the rights that are";
                string row_524 = "specifically granted under this License.  You may not convey a covered";
                string row_525 = "work if you are a party to an arrangement with a third party that is";
                string row_526 = "in the business of distributing software, under which you make payment";
                string row_527 = "to the third party based on the extent of your activity of conveying";
                string row_528 = "the work, and under which the third party grants, to any of the";
                string row_529 = "parties who would receive the covered work from you, a discriminatory";
                string row_530 = "patent license (a) in connection with copies of the covered work";
                string row_531 = "conveyed by you (or copies made from those copies), or (b) primarily";
                string row_532 = "for and in connection with specific products or compilations that";
                string row_533 = "contain the covered work, unless you entered into that arrangement,";
                string row_534 = "or that patent license was granted, prior to 28 March 2007.";
                string row_535 = "";
                string row_536 = "  Nothing in this License shall be construed as excluding or limiting";
                string row_537 = "any implied license or other defenses to infringement that may";
                string row_538 = "otherwise be available to you under applicable patent law.";
                string row_539 = "";
                string row_540 = "  12. No Surrender of Others' Freedom.";
                string row_541 = "";
                string row_542 = "  If conditions are imposed on you (whether by court order, agreement or";
                string row_543 = "otherwise) that contradict the conditions of this License, they do not";
                string row_544 = "excuse you from the conditions of this License.  If you cannot convey a";
                string row_545 = "covered work so as to satisfy simultaneously your obligations under this";
                string row_546 = "License and any other pertinent obligations, then as a consequence you may";
                string row_547 = "not convey it at all.  For example, if you agree to terms that obligate you";
                string row_548 = "to collect a royalty for further conveying from those to whom you convey";
                string row_549 = "the Program, the only way you could satisfy both those terms and this";
                string row_550 = "License would be to refrain entirely from conveying the Program.";
                string row_551 = "";
                string row_552 = "  13. Use with the GNU Affero General Public License.";
                string row_553 = "";
                string row_554 = "  Notwithstanding any other provision of this License, you have";
                string row_555 = "permission to link or combine any covered work with a work licensed";
                string row_556 = "under version 3 of the GNU Affero General Public License into a single";
                string row_557 = "combined work, and to convey the resulting work.  The terms of this";
                string row_558 = "License will continue to apply to the part which is the covered work,";
                string row_559 = "but the special requirements of the GNU Affero General Public License,";
                string row_560 = "section 13, concerning interaction through a network will apply to the";

                string block_53 = String.Concat(row_521, "\n", row_522, "\n", row_523, "\n", row_524, "\n", row_525, "\n", row_526, "\n", row_527, "\n", row_528, "\n", row_529, "\n", row_530, "\n");
                string block_54 = String.Concat(row_531, "\n", row_532, "\n", row_533, "\n", row_534, "\n", row_535, "\n", row_536, "\n", row_537, "\n", row_538, "\n", row_539, "\n", row_540, "\n");
                string block_55 = String.Concat(row_541, "\n", row_542, "\n", row_543, "\n", row_544, "\n", row_545, "\n", row_546, "\n", row_547, "\n", row_548, "\n", row_549, "\n", row_550, "\n");
                string block_56 = String.Concat(row_551, "\n", row_552, "\n", row_553, "\n", row_554, "\n", row_555, "\n", row_556, "\n", row_557, "\n", row_558, "\n", row_559, "\n", row_560);

                string page_14 = String.Concat(block_53, block_54, block_55, block_56);

                return page_14;
            }
            else if (page_no == 15)
            {
                string row_561 = "combination as such.";
                string row_562 = "";
                string row_563 = "  14. Revised Versions of this License.";
                string row_564 = "";
                string row_565 = "  The Free Software Foundation may publish revised and/or new versions of";
                string row_566 = "the GNU General Public License from time to time.  Such new versions will";
                string row_567 = "be similar in spirit to the present version, but may differ in detail to";
                string row_568 = "address new problems or concerns.";
                string row_569 = "";
                string row_570 = "  Each version is given a distinguishing version number.  If the";
                string row_571 = "Program specifies that a certain numbered version of the GNU General";
                string row_572 = "Public License \"or any later version\" applies to it, you have the";
                string row_573 = "option of following the terms and conditions either of that numbered";
                string row_574 = "version or of any later version published by the Free Software";
                string row_575 = "Foundation.  If the Program does not specify a version number of the";
                string row_576 = "GNU General Public License, you may choose any version ever published";
                string row_577 = "by the Free Software Foundation.";
                string row_578 = "";
                string row_579 = "  If the Program specifies that a proxy can decide which future";
                string row_580 = "versions of the GNU General Public License can be used, that proxy's";
                string row_581 = "public statement of acceptance of a version permanently authorizes you";
                string row_582 = "to choose that version for the Program.";
                string row_583 = "";
                string row_584 = "  Later license versions may give you additional or different";
                string row_585 = "permissions.  However, no additional obligations are imposed on any";
                string row_586 = "author or copyright holder as a result of your choosing to follow a";
                string row_587 = "later version.";
                string row_588 = "";
                string row_589 = "  15. Disclaimer of Warranty.";
                string row_590 = "";
                string row_591 = "  THERE IS NO WARRANTY FOR THE PROGRAM, TO THE EXTENT PERMITTED BY";
                string row_592 = "APPLICABLE LAW.  EXCEPT WHEN OTHERWISE STATED IN WRITING THE COPYRIGHT";
                string row_593 = "HOLDERS AND/OR OTHER PARTIES PROVIDE THE PROGRAM \"AS IS\" WITHOUT WARRANTY";
                string row_594 = "OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING, BUT NOT LIMITED TO,";
                string row_595 = "THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR";
                string row_596 = "PURPOSE.  THE ENTIRE RISK AS TO THE QUALITY AND PERFORMANCE OF THE PROGRAM";
                string row_597 = "IS WITH YOU.  SHOULD THE PROGRAM PROVE DEFECTIVE, YOU ASSUME THE COST OF";
                string row_598 = "ALL NECESSARY SERVICING, REPAIR OR CORRECTION.";
                string row_599 = "";
                string row_600 = "  16. Limitation of Liability.";

                string block_57 = String.Concat(row_561, "\n", row_562, "\n", row_563, "\n", row_564, "\n", row_565, "\n", row_566, "\n", row_567, "\n", row_568, "\n", row_569, "\n", row_570, "\n");
                string block_58 = String.Concat(row_571, "\n", row_572, "\n", row_573, "\n", row_574, "\n", row_575, "\n", row_576, "\n", row_577, "\n", row_578, "\n", row_579, "\n", row_580, "\n");
                string block_59 = String.Concat(row_581, "\n", row_582, "\n", row_583, "\n", row_584, "\n", row_585, "\n", row_586, "\n", row_587, "\n", row_588, "\n", row_589, "\n", row_590, "\n");
                string block_60 = String.Concat(row_591, "\n", row_592, "\n", row_593, "\n", row_594, "\n", row_595, "\n", row_596, "\n", row_597, "\n", row_598, "\n", row_599, "\n", row_600);

                string page_15 = String.Concat(block_57, block_58, block_59, block_60);

                return page_15;
            }
            else if (page_no == 16)
            {
                string row_601 = "";
                string row_602 = "  IN NO EVENT UNLESS REQUIRED BY APPLICABLE LAW OR AGREED TO IN WRITING";
                string row_603 = "WILL ANY COPYRIGHT HOLDER, OR ANY OTHER PARTY WHO MODIFIES AND/OR CONVEYS";
                string row_604 = "THE PROGRAM AS PERMITTED ABOVE, BE LIABLE TO YOU FOR DAMAGES, INCLUDING ANY";
                string row_605 = "GENERAL, SPECIAL, INCIDENTAL OR CONSEQUENTIAL DAMAGES ARISING OUT OF THE";
                string row_606 = "USE OR INABILITY TO USE THE PROGRAM (INCLUDING BUT NOT LIMITED TO LOSS OF";
                string row_607 = "DATA OR DATA BEING RENDERED INACCURATE OR LOSSES SUSTAINED BY YOU OR THIRD";
                string row_608 = "PARTIES OR A FAILURE OF THE PROGRAM TO OPERATE WITH ANY OTHER PROGRAMS),";
                string row_609 = "EVEN IF SUCH HOLDER OR OTHER PARTY HAS BEEN ADVISED OF THE POSSIBILITY OF";
                string row_610 = "SUCH DAMAGES.";
                string row_611 = "";
                string row_612 = "  17. Interpretation of Sections 15 and 16.";
                string row_613 = "";
                string row_614 = "  If the disclaimer of warranty and limitation of liability provided";
                string row_615 = "above cannot be given local legal effect according to their terms,";
                string row_616 = "reviewing courts shall apply local law that most closely approximates";
                string row_617 = "an absolute waiver of all civil liability in connection with the";
                string row_618 = "Program, unless a warranty or assumption of liability accompanies a";
                string row_619 = "copy of the Program in return for a fee.";
                string row_620 = "";
                string row_621 = "                     END OF TERMS AND CONDITIONS";

                string block_61 = String.Concat(row_601, "\n", row_602, "\n", row_603, "\n", row_604, "\n", row_605, "\n", row_606, "\n", row_607, "\n", row_608, "\n", row_609, "\n", row_610, "\n");
                string block_62 = String.Concat(row_611, "\n", row_612, "\n", row_613, "\n", row_614, "\n", row_615, "\n", row_616, "\n", row_617, "\n", row_618, "\n", row_619, "\n", row_620, "\n");
                string block_63 = row_621;

                string page_16 = String.Concat(block_61, block_62, block_63);

                return page_16;
            }
            else
            {
                string blankpage = "";
                return blankpage;
            }
        }
    }
}
