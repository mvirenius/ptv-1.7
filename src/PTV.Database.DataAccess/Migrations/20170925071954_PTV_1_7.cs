﻿/**
 * The MIT License
 * Copyright (c) 2016 Population Register Centre (VRK)
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using PTV.Database.DataAccess.Migrations.Base;
using PTV.Database.DataAccess.Migrations.PTV_1_6_Partial;
using PTV.Database.DataAccess.Migrations.PTV_1_7_Partial;

namespace PTV.Database.DataAccess.Migrations
{
    public partial class PTV_1_7 : Migration
    {
        readonly List<IPartialMigration> migrations = new List<IPartialMigration>
        {
            new NameTypesKeys(),
            new chargeType_rename(),
            new NameTypeForNewForeingAddress(),
            new QuartzInit(),
            new AreaCodesFix(),
            new IsValid(),
            new Organization_EInvoicing(),
            new GeneralDescriptionServiceChannelTables(),
            new ServiceCollection(),
            new Rename_Longtitude_to_Longitude(),
            new IsASTIConnection(),
            new FintoDescription(),
            new CFGRequestFilter(),
            new ConnectionOrder(),
            new ConnectionDetails(),
            new COUNTRY_CODE_NULLABLE(),
            new ConnectionDetailsKeys(),
            new daily_intervals_order(),
            new PrintableFormUrlOrderNumber(),
            new PrintableFormDeliveryAddress(),
            new form_state()
        };

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrations.ForEach(m =>
            {
                m.Up(migrationBuilder);
            });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrations.ForEach(m =>
            {
                m.Down(migrationBuilder);
            });
        }
    }
}
