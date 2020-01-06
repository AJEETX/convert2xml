# convert custom data to xml ![GitHub release](https://img.shields.io/github/release/ajeetx/convert2xml.svg?style=for-the-badge) ![Maintenance](https://img.shields.io/maintenance/yes/2021.svg?style=for-the-badge)

 | ![GitHub Release Date](https://img.shields.io/github/release-date/ajeetx/convert2xml.svg?style=plastic) | ![Website](https://img.shields.io/website-stable-offline-green-red/http/ajeetx.github.io/convert2xml.svg?label=status&style=plastic) | [![Build Status](https://travis-ci.org/AJEETX/convert2xml.png?branch=master&style=for-the-badge)](https://travis-ci.org/AJEETX/convert2xml) | [![.Net Framework](https://img.shields.io/badge/DotNet-4.5-blue.svg?style=plastic)](https://www.microsoft.com/en-au/download/details.aspx?id=42642) | ![GitHub language count](https://img.shields.io/github/languages/count/ajeetx/convert2xml.svg?style=plastic)| ![GitHub top language](https://img.shields.io/github/languages/top/ajeetx/convert2xml.svg) |![GitHub repo size in bytes](https://img.shields.io/github/repo-size/ajeetx/convert2xml.svg) 
| ---          | ---        | ---  | --- | --- | --- | --- |


> a simple console based system . converts custom data to xml format

> Wiring up the setup:

    > please download or clone the repo to your computer
    > Open the solution file 'Converter.Demo.sln' from VisualStudio 2017 
    > copy the below sample input save as data.csv file and place in the Converter application bin folder
    > place the same csv file into Converter test application bin/debug folder

All set. 


### below is sample csv input 

```
H,PO2008-01,SHANGHAI FURNITURE COMPANY,CNSHA,AUMEL,1/05/2014
D,PO2008-01,1,RED LOUNGES,100,
D,PO2008-01,2,GREY LOUNGES,50,
H,PO2008-02,YANTIAN INDUSTRIAL PRODUCTS,CNYTN,AUSYD,16/05/2014
D,PO2008-02,1,BAR STOOLS,40,
D,PO2008-02,2,METAL TABLES,75,
H,PO2008-03,SHANGHAI FURNITURE COMPANY,CNSHA,,1/07/2014
D,PO2008-03,1,RED CHAIRS,33,
H,PO2008-04,SHANGHAI FURNITURE COMPANY,CNSHA,AUMEL,30/06/2014
D,PO2008-04,1,GREEN BEDS,33,
D,PO2008-04,2,GREEN TABLES,44,
D,PO2008-04,3,GREEN LAMPS,55,
```


Please run the application 

#### Application convert to below xml 
> output in 'Converter' project bin/debug folder

```
<PurchaseOrders>
  <PurchaseOrder>
    <CustomerPo>PO2008-01</CustomerPo>
    <Supplier>SFC01</Supplier>
    <Origin>CNSHA</Origin>
    <Destination>AUMEL</Destination>
    <CargoReady>2014-05-01</CargoReady>
    <Lines>
      <PurchaseOrderLine>
        <LineNumber>1</LineNumber>
        <ProductDescription>RED LOUNGES</ProductDescription>
        <OrderQty>100</OrderQty>
      </PurchaseOrderLine>
      <PurchaseOrderLine>
        <LineNumber>2</LineNumber>
        <ProductDescription>GREY LOUNGES</ProductDescription>
        <OrderQty>50</OrderQty>
      </PurchaseOrderLine>
    </Lines>
  </PurchaseOrder>
  <PurchaseOrder>
    <CustomerPo>PO2008-02</CustomerPo>
    <Supplier>YIP-01</Supplier>
    <Origin>CNYTN</Origin>
    <Destination>AUSYD</Destination>
    <CargoReady>2014-05-16</CargoReady>
    <Lines>
      <PurchaseOrderLine>
        <LineNumber>1</LineNumber>
        <ProductDescription>BAR STOOLS</ProductDescription>
        <OrderQty>40</OrderQty>
      </PurchaseOrderLine>
      <PurchaseOrderLine>
        <LineNumber>2</LineNumber>
        <ProductDescription>METAL TABLES</ProductDescription>
        <OrderQty>75</OrderQty>
      </PurchaseOrderLine>
    </Lines>
  </PurchaseOrder>
  <PurchaseOrder>
    <CustomerPo>PO2008-03</CustomerPo>
    <Supplier>SFC01</Supplier>
    <Origin>CNSHA</Origin>
    <Destination>AUMEL</Destination>
    <CargoReady>2014-07-01</CargoReady>
    <Lines>
      <PurchaseOrderLine>
        <LineNumber>1</LineNumber>
        <ProductDescription>RED CHAIRS</ProductDescription>
        <OrderQty>33</OrderQty>
      </PurchaseOrderLine>
    </Lines>
  </PurchaseOrder>
  <PurchaseOrder>
    <CustomerPo>PO2008-04</CustomerPo>
    <Supplier>SFC01</Supplier>
    <Origin>CNSHA</Origin>
    <Destination>AUMEL</Destination>
    <CargoReady>2014-06-30</CargoReady>
    <Lines>
      <PurchaseOrderLine>
        <LineNumber>1</LineNumber>
        <ProductDescription>GREEN BEDS</ProductDescription>
        <OrderQty>33</OrderQty>
      </PurchaseOrderLine>
      <PurchaseOrderLine>
        <LineNumber>2</LineNumber>
        <ProductDescription>GREEN TABLES</ProductDescription>
        <OrderQty>44</OrderQty>
      </PurchaseOrderLine>
      <PurchaseOrderLine>
        <LineNumber>3</LineNumber>
        <ProductDescription>GREEN LAMPS</ProductDescription>
        <OrderQty>55</OrderQty>
      </PurchaseOrderLine>
    </Lines>
  </PurchaseOrder>
</PurchaseOrders>
```

    ```
    happy coding
    ```
### Support or Contact

Having any trouble? Check out our [documentation](https://github.com/AJEETX/ParkingCalculation.Demo/blob/master/README.md) or [contact support](mailto:ajeetkumar@email.com) and we’ll help you sort it out.

|  Counter   | Contributor | Disclaimer
| ---        | ---         | --- |
|[ ![HitCount](http://hits.dwyl.io/ajeetx/convert2xml/projects/1.svg)](http://hits.dwyl.io/ajeetx/convert2xml/projects/1) | ![GitHub contributors](https://img.shields.io/github/contributors/ajeetx/convert2xml.svg?style=plastic)|![license](https://img.shields.io/github/license/ajeetx/convert2xml.svg?style=plastic)
