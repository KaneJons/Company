PGDMP     4    8                z            EnterpriseDirectory    14.3    14.3                0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false                       0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false                       0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false                       1262    16568    EnterpriseDirectory    DATABASE     r   CREATE DATABASE "EnterpriseDirectory" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE = 'Russian_Russia.utf8';
 %   DROP DATABASE "EnterpriseDirectory";
                postgres    false            ?            1259    16612    consolidation_of_the_head    TABLE     ?   CREATE TABLE public.consolidation_of_the_head (
    nomer integer NOT NULL,
    id_subdivision integer,
    id_manager integer,
    data date
);
 -   DROP TABLE public.consolidation_of_the_head;
       public         heap    postgres    false            ?            1259    16569 
   enterprise    TABLE     ?   CREATE TABLE public.enterprise (
    id integer NOT NULL,
    name character varying(50) NOT NULL,
    short_name character varying(10) NOT NULL
);
    DROP TABLE public.enterprise;
       public         heap    postgres    false            ?            1259    16592    fixing_the_location    TABLE     ?   CREATE TABLE public.fixing_the_location (
    nomer integer NOT NULL,
    id_subdivision integer,
    location character varying(60),
    data date
);
 '   DROP TABLE public.fixing_the_location;
       public         heap    postgres    false            ?            1259    16587    manager    TABLE     ?   CREATE TABLE public.manager (
    id integer NOT NULL,
    fio character varying(50) NOT NULL,
    post character varying(30) NOT NULL
);
    DROP TABLE public.manager;
       public         heap    postgres    false            ?            1259    16602    phone_pinning    TABLE     ?   CREATE TABLE public.phone_pinning (
    nomer integer NOT NULL,
    id_subdivision integer,
    telephone character(16),
    data date
);
 !   DROP TABLE public.phone_pinning;
       public         heap    postgres    false            ?            1259    16574    subdivision    TABLE     8  CREATE TABLE public.subdivision (
    id integer NOT NULL,
    name character varying(50) NOT NULL,
    short_name character varying(25) NOT NULL,
    id_enterprise integer NOT NULL,
    kind_of_activity character varying(100) NOT NULL,
    email_address character varying(50),
    date_of_email_address date
);
    DROP TABLE public.subdivision;
       public         heap    postgres    false            ?            1259    16668    usser    TABLE     |   CREATE TABLE public.usser (
    id integer NOT NULL,
    login character varying(15),
    password character varying(20)
);
    DROP TABLE public.usser;
       public         heap    postgres    false                      0    16612    consolidation_of_the_head 
   TABLE DATA           \   COPY public.consolidation_of_the_head (nomer, id_subdivision, id_manager, data) FROM stdin;
    public          postgres    false    214   %                 0    16569 
   enterprise 
   TABLE DATA           :   COPY public.enterprise (id, name, short_name) FROM stdin;
    public          postgres    false    209   ?%                 0    16592    fixing_the_location 
   TABLE DATA           T   COPY public.fixing_the_location (nomer, id_subdivision, location, data) FROM stdin;
    public          postgres    false    212   T&                 0    16587    manager 
   TABLE DATA           0   COPY public.manager (id, fio, post) FROM stdin;
    public          postgres    false    211   ?'                 0    16602    phone_pinning 
   TABLE DATA           O   COPY public.phone_pinning (nomer, id_subdivision, telephone, data) FROM stdin;
    public          postgres    false    213   ?(                 0    16574    subdivision 
   TABLE DATA           ?   COPY public.subdivision (id, name, short_name, id_enterprise, kind_of_activity, email_address, date_of_email_address) FROM stdin;
    public          postgres    false    210   x)                 0    16668    usser 
   TABLE DATA           4   COPY public.usser (id, login, password) FROM stdin;
    public          postgres    false    215   ?+       ~           2606    16616 8   consolidation_of_the_head consolidation_of_the_head_pkey 
   CONSTRAINT     y   ALTER TABLE ONLY public.consolidation_of_the_head
    ADD CONSTRAINT consolidation_of_the_head_pkey PRIMARY KEY (nomer);
 b   ALTER TABLE ONLY public.consolidation_of_the_head DROP CONSTRAINT consolidation_of_the_head_pkey;
       public            postgres    false    214            t           2606    16573    enterprise enterprise_pkey 
   CONSTRAINT     X   ALTER TABLE ONLY public.enterprise
    ADD CONSTRAINT enterprise_pkey PRIMARY KEY (id);
 D   ALTER TABLE ONLY public.enterprise DROP CONSTRAINT enterprise_pkey;
       public            postgres    false    209            z           2606    16596 ,   fixing_the_location fixing_the_location_pkey 
   CONSTRAINT     m   ALTER TABLE ONLY public.fixing_the_location
    ADD CONSTRAINT fixing_the_location_pkey PRIMARY KEY (nomer);
 V   ALTER TABLE ONLY public.fixing_the_location DROP CONSTRAINT fixing_the_location_pkey;
       public            postgres    false    212            x           2606    16591    manager manager_pkey 
   CONSTRAINT     R   ALTER TABLE ONLY public.manager
    ADD CONSTRAINT manager_pkey PRIMARY KEY (id);
 >   ALTER TABLE ONLY public.manager DROP CONSTRAINT manager_pkey;
       public            postgres    false    211            |           2606    16606     phone_pinning phone_pinning_pkey 
   CONSTRAINT     a   ALTER TABLE ONLY public.phone_pinning
    ADD CONSTRAINT phone_pinning_pkey PRIMARY KEY (nomer);
 J   ALTER TABLE ONLY public.phone_pinning DROP CONSTRAINT phone_pinning_pkey;
       public            postgres    false    213            v           2606    16578    subdivision subdivision_pkey 
   CONSTRAINT     Z   ALTER TABLE ONLY public.subdivision
    ADD CONSTRAINT subdivision_pkey PRIMARY KEY (id);
 F   ALTER TABLE ONLY public.subdivision DROP CONSTRAINT subdivision_pkey;
       public            postgres    false    210            ?           2606    16672    usser usser_pkey 
   CONSTRAINT     N   ALTER TABLE ONLY public.usser
    ADD CONSTRAINT usser_pkey PRIMARY KEY (id);
 :   ALTER TABLE ONLY public.usser DROP CONSTRAINT usser_pkey;
       public            postgres    false    215            ?           2606    16622 C   consolidation_of_the_head consolidation_of_the_head_id_manager_fkey    FK CONSTRAINT     ?   ALTER TABLE ONLY public.consolidation_of_the_head
    ADD CONSTRAINT consolidation_of_the_head_id_manager_fkey FOREIGN KEY (id_manager) REFERENCES public.manager(id);
 m   ALTER TABLE ONLY public.consolidation_of_the_head DROP CONSTRAINT consolidation_of_the_head_id_manager_fkey;
       public          postgres    false    211    214    3192            ?           2606    16617 G   consolidation_of_the_head consolidation_of_the_head_id_subdivision_fkey    FK CONSTRAINT     ?   ALTER TABLE ONLY public.consolidation_of_the_head
    ADD CONSTRAINT consolidation_of_the_head_id_subdivision_fkey FOREIGN KEY (id_subdivision) REFERENCES public.subdivision(id);
 q   ALTER TABLE ONLY public.consolidation_of_the_head DROP CONSTRAINT consolidation_of_the_head_id_subdivision_fkey;
       public          postgres    false    214    3190    210            ?           2606    16597 ;   fixing_the_location fixing_the_location_id_subdivision_fkey    FK CONSTRAINT     ?   ALTER TABLE ONLY public.fixing_the_location
    ADD CONSTRAINT fixing_the_location_id_subdivision_fkey FOREIGN KEY (id_subdivision) REFERENCES public.subdivision(id);
 e   ALTER TABLE ONLY public.fixing_the_location DROP CONSTRAINT fixing_the_location_id_subdivision_fkey;
       public          postgres    false    3190    212    210            ?           2606    16607 /   phone_pinning phone_pinning_id_subdivision_fkey    FK CONSTRAINT     ?   ALTER TABLE ONLY public.phone_pinning
    ADD CONSTRAINT phone_pinning_id_subdivision_fkey FOREIGN KEY (id_subdivision) REFERENCES public.subdivision(id);
 Y   ALTER TABLE ONLY public.phone_pinning DROP CONSTRAINT phone_pinning_id_subdivision_fkey;
       public          postgres    false    3190    213    210            ?           2606    16579 *   subdivision subdivision_id_enterprise_fkey    FK CONSTRAINT     ?   ALTER TABLE ONLY public.subdivision
    ADD CONSTRAINT subdivision_id_enterprise_fkey FOREIGN KEY (id_enterprise) REFERENCES public.enterprise(id);
 T   ALTER TABLE ONLY public.subdivision DROP CONSTRAINT subdivision_id_enterprise_fkey;
       public          postgres    false    209    3188    210               g   x?EN??0;?]???:?w??ssh\$?A1Ca??+???????F)?_a?gJ1?}We?fr??;?-b?bѡL???U:B{?Xd???f%?????}z         ?   x??PI?0;'?????S????r@B??~??(??/x~?'Hp?????Ό
IP?!?,1??,BO????D'+??Xl?ˆ?W;?S??đ?????؉??>?MFz?#Jkz??GE??p?S??$?V??8۩A?J???R???????[???^?GZ???D???????L???"t_???7y??         E  x???MN?0???)|?:???i??a?fS	?"??_?KJ?HАr???Ɖ?n]X??yo>??*W?5?H?yN?X?im?瞛???:Cw?F{9b?????x\?M??:??iEk?b?\?a?5?i???1??gj}?s????Q?%|?????E?G"_?2??e*??'???????C??P??x??5?H?$?N @?
??NO??	??F?2|????hH??ָ?>C?????2????Fً????A?'WsC??????1?"?K?%ΐ??_.r3?p?~???G?37?!Ne?v???i?2t/1?????8????K??_?\a!         ?   x?u?MN?0???)|??M??. ??		6p??Ċ[??
on?76?T??<????yfo?褑?{?????eB?y?????*?J???I?pp??
8J?Q*;7ؠe?D_??=Z?W?I????Y?
[F??'?x??{k???q??I????;U?%???\g8L??h?H??P<?h???x???@?9?P??χ?S???H?p̌S?~d??!?"w???1k????\f?????쵔Jjy??k?c]4?         ?   x?5?An1??%?V???왕??2l|⧪ff"{eU??2???}?ւ??*'??~??3L???3?????m?
J!z?@R?C/O?!???E?}????Stu???Y(ƺ|5oh?O????gE7
????붠???̖oo=?wU?w????5w?u??Y???B?D?/?8i         B  x?}S?j?P]_}?> 2z?$??C
AM??Vk;i???-)8??@[ZhY???QbK????3#!?]??5w??9g?ME?he>??TН?#e?`????5?[??D????{?D8q???z??'?sJ?7a?K?~.ㅢ???	?S??͔?xr??8|?ø۾???N7???qW?3p?}?۵P??#???/j??o!??6#?L?@R??p???~R????"oa㣀?0s??^S?e ?)??XaCEjf?+Z?Ý??}?????LH?52ᗙِ??S??4??A???E?a?{-???ae?#??}B??fK!??BG?x ?1??є.?V?&????(O?g.?9iѵ????@E?LS??E???BE?a??_??^?:{G????????[?????W?95??'??[?`~?
b?g??ܘ1J?????
?x?v@M?6#???wx?IZƹ?7X2?Y!?r.h?U;??C????1???
???;?qq|fހ??????0?+\???N?'????\??gX???Q?Iu?mx???DLB?l?@?˩j??Wb3?r????/??m??<??????M??c?lX??????         3   x?3??0???{?x˅m?^l??2??0???;@??8?b???? ??"     