PGDMP                      |            Durka    16.3    16.2 5    �           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false            �           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false            �           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false            �           1262    16572    Durka    DATABASE     {   CREATE DATABASE "Durka" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'Russian_Russia.1251';
    DROP DATABASE "Durka";
                postgres    false            �            1259    16573    account    TABLE     �   CREATE TABLE public.account (
    id integer NOT NULL,
    login character varying(20) NOT NULL,
    password character varying(20) NOT NULL,
    status boolean NOT NULL
);
    DROP TABLE public.account;
       public         heap    postgres    false            �            1259    16576    account_id_seq    SEQUENCE     �   ALTER TABLE public.account ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.account_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          postgres    false    215            �            1259    16577    chamber    TABLE     �   CREATE TABLE public.chamber (
    id integer NOT NULL,
    capacity integer NOT NULL,
    type character varying(30) NOT NULL,
    area integer NOT NULL
);
    DROP TABLE public.chamber;
       public         heap    postgres    false            �            1259    16580 	   diagnosis    TABLE     �   CREATE TABLE public.diagnosis (
    id integer NOT NULL,
    severeness character varying(20) NOT NULL,
    description character varying(100),
    name character varying(30) NOT NULL
);
    DROP TABLE public.diagnosis;
       public         heap    postgres    false            �            1259    16583    diagnoz_id_seq    SEQUENCE     �   ALTER TABLE public.diagnosis ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.diagnoz_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          postgres    false    218            �            1259    16584    doctor    TABLE     U  CREATE TABLE public.doctor (
    id integer NOT NULL,
    name character varying(20) NOT NULL,
    surname character varying(20) NOT NULL,
    thirdname character varying(20),
    specialization character varying(50) NOT NULL,
    accountid integer NOT NULL,
    cabinetnumber integer NOT NULL,
    phonenumber character varying NOT NULL
);
    DROP TABLE public.doctor;
       public         heap    postgres    false            �            1259    16589    doctor_and_patient    TABLE     �   CREATE TABLE public.doctor_and_patient (
    id integer NOT NULL,
    doctorid integer NOT NULL,
    patientid integer NOT NULL
);
 &   DROP TABLE public.doctor_and_patient;
       public         heap    postgres    false            �            1259    16595    palata_id_seq    SEQUENCE     �   ALTER TABLE public.chamber ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.palata_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          postgres    false    217            �            1259    16596    patient    TABLE       CREATE TABLE public.patient (
    id integer NOT NULL,
    name character varying(20) NOT NULL,
    surname character varying(20) NOT NULL,
    thirdname character varying(20),
    chamberid integer NOT NULL,
    rating integer NOT NULL,
    accountid integer NOT NULL
);
    DROP TABLE public.patient;
       public         heap    postgres    false            �            1259    16599    patient_and_diagnosis    TABLE     �   CREATE TABLE public.patient_and_diagnosis (
    id integer NOT NULL,
    patientid integer NOT NULL,
    diagnosisid integer NOT NULL
);
 )   DROP TABLE public.patient_and_diagnosis;
       public         heap    postgres    false            �            1259    16602    schedule    TABLE     �   CREATE TABLE public.schedule (
    id integer NOT NULL,
    starttime time without time zone NOT NULL,
    endtime time without time zone NOT NULL,
    action character varying NOT NULL,
    doctorid integer NOT NULL,
    patientid integer NOT NULL
);
    DROP TABLE public.schedule;
       public         heap    postgres    false            �            1259    16607    schedule_id_seq    SEQUENCE     �   ALTER TABLE public.schedule ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.schedule_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          postgres    false    225            �            1259    16608    shiz_i_diagnoz_id_seq    SEQUENCE     �   ALTER TABLE public.patient_and_diagnosis ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.shiz_i_diagnoz_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          postgres    false    224            �            1259    16609    shizik_id_seq    SEQUENCE     �   ALTER TABLE public.patient ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.shizik_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          postgres    false    223            �            1259    16610    vrach_i_shiz_id_seq    SEQUENCE     �   ALTER TABLE public.doctor_and_patient ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.vrach_i_shiz_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          postgres    false    221            �            1259    16611    vrach_id_seq    SEQUENCE     �   ALTER TABLE public.doctor ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.vrach_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          postgres    false    220            �          0    16573    account 
   TABLE DATA           >   COPY public.account (id, login, password, status) FROM stdin;
    public          postgres    false    215   �>       �          0    16577    chamber 
   TABLE DATA           ;   COPY public.chamber (id, capacity, type, area) FROM stdin;
    public          postgres    false    217   R?       �          0    16580 	   diagnosis 
   TABLE DATA           F   COPY public.diagnosis (id, severeness, description, name) FROM stdin;
    public          postgres    false    218   �?       �          0    16584    doctor 
   TABLE DATA           u   COPY public.doctor (id, name, surname, thirdname, specialization, accountid, cabinetnumber, phonenumber) FROM stdin;
    public          postgres    false    220   W@       �          0    16589    doctor_and_patient 
   TABLE DATA           E   COPY public.doctor_and_patient (id, doctorid, patientid) FROM stdin;
    public          postgres    false    221   ?A       �          0    16596    patient 
   TABLE DATA           ]   COPY public.patient (id, name, surname, thirdname, chamberid, rating, accountid) FROM stdin;
    public          postgres    false    223   kA       �          0    16599    patient_and_diagnosis 
   TABLE DATA           K   COPY public.patient_and_diagnosis (id, patientid, diagnosisid) FROM stdin;
    public          postgres    false    224   �A       �          0    16602    schedule 
   TABLE DATA           W   COPY public.schedule (id, starttime, endtime, action, doctorid, patientid) FROM stdin;
    public          postgres    false    225   B       �           0    0    account_id_seq    SEQUENCE SET     <   SELECT pg_catalog.setval('public.account_id_seq', 6, true);
          public          postgres    false    216            �           0    0    diagnoz_id_seq    SEQUENCE SET     <   SELECT pg_catalog.setval('public.diagnoz_id_seq', 2, true);
          public          postgres    false    219            �           0    0    palata_id_seq    SEQUENCE SET     ;   SELECT pg_catalog.setval('public.palata_id_seq', 2, true);
          public          postgres    false    222            �           0    0    schedule_id_seq    SEQUENCE SET     =   SELECT pg_catalog.setval('public.schedule_id_seq', 2, true);
          public          postgres    false    226            �           0    0    shiz_i_diagnoz_id_seq    SEQUENCE SET     C   SELECT pg_catalog.setval('public.shiz_i_diagnoz_id_seq', 2, true);
          public          postgres    false    227                        0    0    shizik_id_seq    SEQUENCE SET     ;   SELECT pg_catalog.setval('public.shizik_id_seq', 2, true);
          public          postgres    false    228                       0    0    vrach_i_shiz_id_seq    SEQUENCE SET     A   SELECT pg_catalog.setval('public.vrach_i_shiz_id_seq', 5, true);
          public          postgres    false    229                       0    0    vrach_id_seq    SEQUENCE SET     :   SELECT pg_catalog.setval('public.vrach_id_seq', 4, true);
          public          postgres    false    230            >           2606    16613    account account_pkey 
   CONSTRAINT     R   ALTER TABLE ONLY public.account
    ADD CONSTRAINT account_pkey PRIMARY KEY (id);
 >   ALTER TABLE ONLY public.account DROP CONSTRAINT account_pkey;
       public            postgres    false    215            @           2606    16615    chamber chamber_pkey 
   CONSTRAINT     R   ALTER TABLE ONLY public.chamber
    ADD CONSTRAINT chamber_pkey PRIMARY KEY (id);
 >   ALTER TABLE ONLY public.chamber DROP CONSTRAINT chamber_pkey;
       public            postgres    false    217            B           2606    16617    diagnosis diagnosis_pkey 
   CONSTRAINT     V   ALTER TABLE ONLY public.diagnosis
    ADD CONSTRAINT diagnosis_pkey PRIMARY KEY (id);
 B   ALTER TABLE ONLY public.diagnosis DROP CONSTRAINT diagnosis_pkey;
       public            postgres    false    218            F           2606    16619 *   doctor_and_patient doctor_and_patient_pkey 
   CONSTRAINT     h   ALTER TABLE ONLY public.doctor_and_patient
    ADD CONSTRAINT doctor_and_patient_pkey PRIMARY KEY (id);
 T   ALTER TABLE ONLY public.doctor_and_patient DROP CONSTRAINT doctor_and_patient_pkey;
       public            postgres    false    221            D           2606    16621    doctor doctor_pkey 
   CONSTRAINT     P   ALTER TABLE ONLY public.doctor
    ADD CONSTRAINT doctor_pkey PRIMARY KEY (id);
 <   ALTER TABLE ONLY public.doctor DROP CONSTRAINT doctor_pkey;
       public            postgres    false    220            J           2606    16625 0   patient_and_diagnosis patient_and_diagnosis_pkey 
   CONSTRAINT     n   ALTER TABLE ONLY public.patient_and_diagnosis
    ADD CONSTRAINT patient_and_diagnosis_pkey PRIMARY KEY (id);
 Z   ALTER TABLE ONLY public.patient_and_diagnosis DROP CONSTRAINT patient_and_diagnosis_pkey;
       public            postgres    false    224            H           2606    16627    patient patient_pkey 
   CONSTRAINT     R   ALTER TABLE ONLY public.patient
    ADD CONSTRAINT patient_pkey PRIMARY KEY (id);
 >   ALTER TABLE ONLY public.patient DROP CONSTRAINT patient_pkey;
       public            postgres    false    223            L           2606    16629    schedule schedule_pkey 
   CONSTRAINT     T   ALTER TABLE ONLY public.schedule
    ADD CONSTRAINT schedule_pkey PRIMARY KEY (id);
 @   ALTER TABLE ONLY public.schedule DROP CONSTRAINT schedule_pkey;
       public            postgres    false    225            P           2606    16630    patient account_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.patient
    ADD CONSTRAINT account_fkey FOREIGN KEY (accountid) REFERENCES public.account(id) NOT VALID;
 >   ALTER TABLE ONLY public.patient DROP CONSTRAINT account_fkey;
       public          postgres    false    223    215    4670            M           2606    16635    doctor account_id_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.doctor
    ADD CONSTRAINT account_id_fkey FOREIGN KEY (accountid) REFERENCES public.account(id) NOT VALID;
 @   ALTER TABLE ONLY public.doctor DROP CONSTRAINT account_id_fkey;
       public          postgres    false    215    4670    220            Q           2606    16640    patient chamber_id_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.patient
    ADD CONSTRAINT chamber_id_fkey FOREIGN KEY (chamberid) REFERENCES public.chamber(id) NOT VALID;
 A   ALTER TABLE ONLY public.patient DROP CONSTRAINT chamber_id_fkey;
       public          postgres    false    4672    217    223            R           2606    16650 $   patient_and_diagnosis diagnosis_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.patient_and_diagnosis
    ADD CONSTRAINT diagnosis_fkey FOREIGN KEY (diagnosisid) REFERENCES public.diagnosis(id) NOT VALID;
 N   ALTER TABLE ONLY public.patient_and_diagnosis DROP CONSTRAINT diagnosis_fkey;
       public          postgres    false    4674    224    218            N           2606    16655    doctor_and_patient doctor_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.doctor_and_patient
    ADD CONSTRAINT doctor_fkey FOREIGN KEY (doctorid) REFERENCES public.doctor(id) NOT VALID;
 H   ALTER TABLE ONLY public.doctor_and_patient DROP CONSTRAINT doctor_fkey;
       public          postgres    false    4676    221    220            T           2606    16660    schedule doctor_id_fkey    FK CONSTRAINT     x   ALTER TABLE ONLY public.schedule
    ADD CONSTRAINT doctor_id_fkey FOREIGN KEY (doctorid) REFERENCES public.doctor(id);
 A   ALTER TABLE ONLY public.schedule DROP CONSTRAINT doctor_id_fkey;
       public          postgres    false    220    225    4676            S           2606    16665 "   patient_and_diagnosis patient_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.patient_and_diagnosis
    ADD CONSTRAINT patient_fkey FOREIGN KEY (patientid) REFERENCES public.patient(id) NOT VALID;
 L   ALTER TABLE ONLY public.patient_and_diagnosis DROP CONSTRAINT patient_fkey;
       public          postgres    false    4680    223    224            O           2606    16670    doctor_and_patient patient_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.doctor_and_patient
    ADD CONSTRAINT patient_fkey FOREIGN KEY (patientid) REFERENCES public.patient(id) NOT VALID;
 I   ALTER TABLE ONLY public.doctor_and_patient DROP CONSTRAINT patient_fkey;
       public          postgres    false    223    4680    221            U           2606    16675    schedule patient_id_fkey    FK CONSTRAINT     {   ALTER TABLE ONLY public.schedule
    ADD CONSTRAINT patient_id_fkey FOREIGN KEY (patientid) REFERENCES public.patient(id);
 B   ALTER TABLE ONLY public.schedule DROP CONSTRAINT patient_id_fkey;
       public          postgres    false    223    225    4680            �   |   x�3�442�4.#NmsSSSc D�ps��d�d���&�p�9��G�8��ئ�Y9�p�%W&b�1��ȬJ�bN�Pg�H�P��gxb^JjQf^z�kqqj^r*�!&�@���qqq �E((      �   G   x�3�4估�b�ņ.v\�$�9����@K/��|a��ƋM6\�ua�ņ��@�����+F��� �L"a      �   �   x�}���0D�v. !A=)&	B �
�b�rl��َ�m��J�y��'����#�͡ �͐�k�"��9��'�<.:!�t $ζ:2��g��7N7%��O��3}4������}B�9W��f��Z�=���2��"��������      �   �   x�e�M
�0�ד��6Mջx����Q�����R�O{�77�5U7&�73߼L$X�B�c�x��]pԉfxP(�Ռ�+^M�R�.��[�*ש��l,����{�kb���%�1jY��8[�WJ��L�D6�No�&޹8��q�!D���/�%[�?�nD]ጜ�Xr�9�%�] �XPp����
�=�W��f�V��尔���xI�4�3�c�.��      �      x�3�4�4�2�4��@�!W� "�      �   m   x�%��	�P���~@�^,&����G&��oR���\��3�$�db,����1���\ă���,�uV�^)*q��0[ezѹ�]y��FWV�k��`5�t�!N���ApH|      �      x�3�4�4�2�B�=... 
      �   :   x�3�44�2 !NC#(����=�^أpaх6^�}a�Ŧ�.��4�4����� =��     