using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GateLogix
{
    public partial class GeneratorPodatki : Form
    {
        string[] firmeImena = { "Wal-Mart Stores", "Exxon Mobil", "General Motors", "Ford Motor", "Enron", "General Electric", "Citigroup", "ChevronTexaco", "Intl. Business Machines", "Philip Morris", "Verizon Communications", "American International Group", "American Electric Power", "Duke Energy", "AT&T", "Boeing", "El Paso", "Home Depot", "Bank of America Corp.", "Fannie Mae", "J.P. Morgan Chase & Co.", "Kroger", "Cardinal Health", "Merck", "State Farm Insurance Cos.", "Reliant Energy", "SBC Communications", "Hewlett-Packard", "Morgan Stanley Dean Witter", "Dynegy", "McKesson", "Sears Roebuck", "Aquila", "Target", "Procter & Gamble", "Merrill Lynch", "AOL Time Warner", "Albertson's", "Berkshire Hathaway", "Kmart", "Freddie Mac", "WorldCom", "Marathon Oil", "Costco Wholesale", "Safeway", "Compaq Computer", "Johnson & Johnson", "Conoco", "Pfizer", "J.C. Penney", "MetLife", "Mirant", "Dell Computer", "Goldman Sachs Group", "United Parcel Service", "Motorola", "Allstate", "TXU", "United Technologies", "Dow Chemical", "ConAgra", "Prudential Financial", "PepsiCo", "Wells Fargo", "Intel", "International Paper", "Delphi", "Sprint", "New York Life Insurance", "E.I. du Pont de Nemours", "Georgia-Pacific", "Microsoft", "Walt Disney", "Aetna", "Ingram Micro", "Lucent Technologies", "Lockheed Martin", "Walgreen", "Bank One Corp.", "TIAA-CREF", "Phillips Petroleum", "BellSouth", "Honeywell International", "UnitedHealth Group", "Viacom", "Supervalu", "PG&E Corp.", "Alcoa", "American Express", "Wachovia Corp.", "Lehman Brothers Holdings", "Cisco Systems", "CVS", "Lowe's", "Sysco", "Bristol-Myers Squibb", "Electronic Data Systems", "Caterpillar", "Coca-Cola", "Archer Daniels Midland", "AutoNation", "Qwest Communications", "FedEx", "Mass. Mutual Life Insurance", "Pharmacia", "FleetBoston Financial", "Cigna", "AMR", "Loews", "Solectron", "Johnson Controls", "Sun Microsystems", "HCA", "Visteon", "Sara Lee", "Washington Mutual", "Tech Data", "Federated Department Stores", "Raytheon", "Xerox", "U.S. Bancorp", "TRW", "Abbott Laboratories", "Northwestern Mutual", "UAL", "Minnesota Mining & Mfg.", "AmerisourceBergen", "Coca-Cola Enterprises", "Fleming", "Emerson Electric", "Best Buy", "Rite Aid", "Publix Super Markets", "Hartford Financial Services", "Exelon", "Nationwide", "Xcel Energy", "Valero Energy", "McDonald's", "Weyerhaeuser", "Kimberly-Clark", "Liberty Mutual Insurance Group", "May Department Stores", "Goodyear Tire & Rubber", "Wyeth", "Occidental Petroleum", "Household International", "Delta Air Lines", "Gap", "Lear", "Northrop Grumman", "Amerada Hess", "Halliburton", "Deere", "Eastman Kodak", "CMS Energy", "Circuit City Stores", "Cinergy", "Anheuser-Busch", "Winn-Dixie Stores", "Avnet", "WellPoint Health Networks", "Sunoco", "Textron", "Edison International", "General Dynamics", "Tenet Healthcare", "Union Pacific", "PacifiCare Health Systems", "Farmland Industries", "Eli Lilly", "Waste Management", "Office Depot", "Williams", "Toys `R` Us", "Oracle", "Tyson Foods", "Staples", "TJX", "Dominion Resources", "Computer Sciences", "Manpower", "Dana", "Anthem", "Allegheny Energy", "Whirlpool", "Humana", "Southern", "Marriott International", "MBNA", "Arrow Electronics", "Health Net", "Marsh & McLennan", "Northwest Airlines", "Public Service Enterprise Group", "Schering-Plough", "Illinois Tool Works", "Comcast", "Consolidated Edison", "Entergy", "AES", "AFLAC", "NiSource", "Nike", "UnumProvident", "H.J. Heinz", "Colgate-Palmolive", "Limited", "John Hancock Financial Services", "Express Scripts", "Burlington Northern Santa Fe", "Agilent Technologies", "National City Corp.", "Fluor", "United Services Automobile Assn.", "Continental Airlines", "Cendant", "St. Paul Cos.", "Guardian Life Ins. Co. of America", "Kellogg", "Principal Financial", "SCI Systems", "Bear Stearns", "R.J. Reynolds Tobacco", "Ashland", "FPL Group", "Progress Energy", "Pepsi Bottling", "SunTrust Banks", "Dillard's", "Smurfit-Stone Container", "Anadarko Petroleum", "Masco", "US Airways Group", "Genuine Parts", "Texas Instruments", "PPG Industries", "CSX", "Conseco", "Gillette", "Sempra Energy", "FirstEnergy", "Clear Channel Communications", "Cenex Harvest States", "DTE Energy", "Aramark", "Aon", "Baxter International", "Chubb", "Alltel", "Calpine", "Nextel Communications", "Kohl's", "Progressive", "American Standard", "Boise Cascade", "KeyCorp", "Applied Materials", "Eaton", "Capital One Financial", "Bank of New York Co.", "Crown Cork & Seal", "EMC", "General Mills", "AdvancePCS", "Automatic Data Processing", "Safeco", "Tricon Global Restaurants", "PNC Financial Services Group", "Newell Rubbermaid", "KeySpan", "Omnicom Group", "Northeast Utilities", "Plains All American Pipeline", "ArvinMeritor", "Oneok", "Avaya", "Unocal", "Interpublic Group", "Navistar International", "Centex", "Campbell Soup", "Fifth Third Bancorp", "First Data", "Premcor", "Lincoln National", "Gannett", "Sonic Automotive", "Corning", "Dean Foods", "BB&T Corp.", "United Auto Group", "Norfolk Southern", "Science Applications Intl.", "Paccar", "Gateway", "Saks", "Lennar", "Avista", "Unisys", "Owens-Illinois", "Avon Products", "Parker Hannifin", "NCR", "Smithfield Foods", "Rohm & Haas", "Conectiv", "ServiceMaster", "PPL", "Air Products & Chemicals", "Cummins", "Idacorp", "State Street Corp.", "Nordstrom", "Caremark Rx", "Allied Waste Industries", "Southwest Airlines", "Medtronic", "Providian Financial", "VF", "Federal-Mogul", "Eastman Chemical", "Baker Hughes", "Pulte Homes", "Apple Computer", "Dollar General", "Fortune Brands", "R.R. Donnelley & Sons", "USA Networks", "Charles Schwab", "BJ's Wholesale Club", "Ikon Office Solutions", "Tribune", "TransMontaigne", "Tesoro Petroleum", "Praxair", "American Family Ins. Group", "Engelhard", "Sherwin-Williams", "Goodrich", "Ryder System", "CNF", "Barnes & Noble", "Graybar Electric", "Countrywide Credit Industries", "AutoZone", "Mattel", "RadioShack", "Owens Corning", "W.W. Grainger", "Adams Resources & Energy", "Pitney Bowes", "Dole Food", "ITT Industries", "KB Home", "McGraw-Hill", "OfficeMax", "Park Place Entertainment", "Sierra Pacific Resources", "Estee Lauder", "Maytag", "Hershey Foods", "Pinnacle West Capital", "Dover", "Micron Technology", "Ameren", "Murphy Oil", "D.R. Horton", "Willamette Industries", "Quantum", "Golden West Financial", "Oxford Health Plans", "Cablevision Systems", "Healthsouth", "Foot Locker", "Administaff", "Black & Decker", "Jabil Circuit", "Mutual of Omaha Insurance", "Rockwell Automation", "Golden State Bancorp", "Longs Drug Stores", "Levi Strauss", "Kelly Services", "NorthWestern", "Cooper Industries", "Computer Associates Intl.", "Comerica", "Temple-Inland", "Lexmark International", "Nucor", "Hormel Foods", "SPX", "Leggett & Platt", "Nash Finch", "Jones Apparel Group", "Cox Communications", "Mellon Financial Corp.", "Sanmina-SCI", "Regions Financial", "Darden Restaurants", "Pathmark Stores", "Amgen", "MGM Mirage", "Pittston", "Phelps Dodge", "Echostar Communications", "Group 1 Automotive", "AK Steel Holding", "Autoliv", "MeadWestvaco", "Encompass Services", "Starwood Hotels & Resorts", "CDW Computer Centers", "Jacobs Engineering Group", "LTV", "Charter Communications", "American Financial Group", "York International", "Wisconsin Energy", "Constellation Energy", "United Stationers", "Clorox", "Advanced Micro Devices", "Steelcase", "Fidelity National Financial", "Peter Kiewit Sons'", "FMC", "Owens & Minor", "Avery Dennison", "Maxtor", "Danaher", "Energy East", "NTL", "Becton Dickinson", "Host Marriott", "First American Corp.", "SouthTrust Corp.", "Pacific LifeCorp", "Harrah's Entertainment", "Ball", "Brunswick", "Family Dollar Stores", "Wesco International", "Ames Department Stores", "Kerr-McGee", "Quest Diagnostics", "Smith International", "Spartan Stores", "USA Education", "Interstate Bakeries", "Roundy's", "Scana", "Liz Claiborne", "Mohawk Industries", "Adelphia Communications", "Big Lots", "Core-Mark International", "Emcor Group", "Foster Wheeler", "Borders Group", "Shopko Stores", "AmSouth Bancorp.", "Puget Energy", "Tenneco Automotive", "Harley-Davidson", "Western Gas Resources", "Bethlehem Steel", "Jefferson-Pilot", "Burlington Resources", "Allmerica Financial", "USG", "Yellow", "Northern Trust Corp.", "Aid Association for Lutherans", "Performance Food Group", "JDS Uniphase", "Lyondell Chemical", "Airborne", "Comdisco", "NSTAR", "OGE Energy", "Staff Leasing", "Enterprise Products", "PepsiAmericas", "Cooper Tire & Rubber", "Coventry Health Care", "Anixter International", "Union Planters Corp.", "Armstrong Holdings", "Equity Office Properties", "Amazon.Com", "Lennox International", "American Axle & Mfg.", "C.H. Robinson Worldwide", "Kindred Healthcare", "Devon Energy", "Sealed Air", "Hilton Hotels", "New York Times", "Hughes Supply", "Vulcan Materials", "Universal", "Auto-Owners Insurance", "Neiman Marcus", "3Com", "H&R Block", "Reebok International", "Ross Stores", "Trigon Healthcare", "Unified Western Grocers", "Payless Shoesource", "TruServ", "Pioneer-Standard Electronics", "Knight-Ridder", "Ace Hardware", "United Rentals", "Fisher Scientific International", "Hasbro", "KPMG Consulting", "Charter One Financial", "Thermo Electron", "Universal Health Services", "A.G. Edwards", "Transocean Sedco Forex", "Rockwell Collins", "Solutia", "Pactiv", "Wackenhut", "Pentair", "Roadway", "Alliant Energy", "Apache", "Ruddick", "Ryland Group", "Crompton", "Lutheran Brotherhood", "IMC Global", "Spherion", "Beverly Enterprises", "Marshall & Ilsley Corp.", "Guidant", "Torchmark", "Manor Care", "Qualcomm", "WPS Resources", "Boston Scientific", "Triad Hospitals", "PolyOne", "Starbucks", "TECO Energy", "Sovereign Bancorp", "Pantry", "Nacco Industries", "Stanley Works", "NVR", "Hercules", "Sonoco Products", "Stryker", "Telephone & Data Systems", "Earthgrains", "M & T Bank Corp.", "Stater Bros. Holdings", "Citizens Communications", "Genesis Health Ventures", "Popular", "Cincinnati Financial", "Henry Schein", "National Service Industries", "Nicor", "AGCO", "Unitrin", "Fleetwood Enterprises", "Michaels Stores", "International Multifoods", "American Greetings", "Reader's Digest Association", "Advance Auto Parts", "Scientific-Atlanta", "Service Corp. International", "Potomac Electric Power", "PetsMart", "Alberto-Culver", "Penn Traffic", "Dura Automotive Systems", "Brinker International", "Sabre Holdings", "UGI", "Tower Automotive", "Mandalay Resort Group", "Footstar", "USFreightways", "First Tennessee National Corp.", "U.S. Industries", "Robert Half International", "Bowater", "Huntington Bancshares", "Timken", "Commercial Metals", "CellStar", "Exide Technologies", "Wm. Wrigley Jr.", "Adolph Coors", "Burlington Coat Factory", "Phoenix Companies", "Washington Post", "ADC Telecommunications", "Constellation Brands", "Bed Bath & Beyond", "Erie Insurance Group", "Wendy's International", "Old Republic International", "McCormick", "OM Group", "Molex", "Louisiana-Pacific", "Franklin Resources", "Ecolab", "PNM Resources", "BorgWarner", "Broadwing", "L-3 Communications", "Weatherford International", "Precision Castparts", "Convergys", "URS", "Pennzoil-Quaker State", "Value City", "Bemis", "Kellwood", "Belk", "Analog Devices", "Whole Foods Market", "Peoples Energy", "Mail-Well", "Republic Services", "La-Z-Boy", "Ryerson Tull", "Chiquita Brands International", "Consolidated Freightways", "Herman Miller", "Budget Group", "BJ Services", "Toll Brothers", "Polo Ralph Lauren", "Nabors Industries", "MDU Resources Group", "Pilgrim's Pride", "Laboratory Corp. of America", "Tellabs", "Western Resources", "Pep Boys-Manny, Moe & Jack", "Equity Residential Properties", "LandAmerica Financial Group", "Vectren", "Cintas", "Omnicare", "Maxxam", "Alaska Air Group", "American National Insurance", "Allegheny Technologies", "Outback Steakhouse", "MDC Holdings", "Sun Healthcare Group", "CenturyTel", "National Semiconductor", "Swift Transportation", "CUNA Mutual Group", "Harsco", "Hillenbrand Industries", "Wyndham International", "Kla-Tencor", "MONY Group", "National Fuel Gas", "J.B. Hunt Transport Services", "Williams-Sonoma", "Snap-On", "Mariner Post-Acute Network", "Insight Enterprises", "Nortek", "PeopleSoft", "Synovus Financial Corp.", "Zale", "America West Holdings", "Affiliated Computer Services", "E*Trade Group", "Simon Property Group", "New Jersey Resources", "Siebel Systems", "Storage Technology", "Quanta Services", "Zions Bancorp.", "Compuware", "RPM", "Bell Microproducts", "General Cable Corporation", "Volt Information Sciences", "Metaldyne", "Charming Shoppes", "Weis Markets", "Dollar Tree Stores", "Beckman Coulter", "Protective Life", "CBRL Group", "Scholastic", "Harris", "Western Digital", "Ingles Markets", "ABM Industries", "W.R. Berkley", "Silgan Holdings", "WGL Holdings", "TravelCenters of America", "Southern Union", "SunGard Data Systems", "Casey's General Stores", "Safeguard Scientifics", "Brown-Forman", "CH2M Hill", "Walter Industries", "Valspar", "Flowserve", "Teleflex", "Trinity Industries", "Ohio Casualty", "Compass Bancshares", "Furniture Brands International", "Fiserv", "Sentry Insurance Group", "DynCorp", "Frontier Oil", "Alpine Group", "Corn Products International", "Health Management Associates", "Marsh Supermarkets", "Lithia Motors", "Magellan Health Services", "Silicon Graphics", "Metris", "Carlisle", "Lubrizol", "Intl. Flavors & Fragrances", "Freeport-McMoRan Copper & Gold", "Jack in the Box", "Worthington Industries", "Brightpoint", "Linens'n Things", "Collins & Aikman", "PSS World Medical", "Amerco", "Terex", "McLeodUSA", "Gold Kist", "Rent A Center", "Kennametal", "Mid Atlantic Medical Services", "Beazer Homes USA", "Seaboard", "Minnesota Life Ins.", "Hon Industries", "Packaging Corp. of America", "LSI Logic", "Dow Jones", "WestPoint Stevens", "Equitable Resources", "Diebold", "W.R. Grace", "Brown Shoe", "Sequa", "Potlatch", "Scotts Company", "National Oilwell", "Primedia", "Hovnanian Enterprises", "Southern States Coop.", "Paychex", "Hawaiian Electric Industries", "Greenpoint Financial", "Harman Intl. Industries", "Bausch & Lomb", "Concord EFS", "Cabot", "Dial", "Energizer Holdings", "Community Health Systems", "Integrated Electrical Services", "Wallace Computer Services", "Allergan", "Metals USA", "EGL", "Allete", "Reliance Steel & Aluminum", "DST Systems", "Viad", "Xilinx", "Raymond James Financial", "Newmont Mining", "Vishay Intertechnology", "EOG Resources", "Expeditors Intl of Washington", "DaVita", "D&K Healthcare Resources", "Applera", "UST", "Flowers Foods", "Airgas", "Applied Industrial Technologies", "Quintiles Transnational", "Tiffany & Co", "Ciena", "PerkinElmer", "Great Lakes Chemical", "Millennium Chemicals", "Crane", "StanCorp Financial", "Maxim Integrated Products", "Agway", "Noble Affiliates", "Jo Ann Stores", "Lands' End", "Cooper Cameron", "Black Hills", "Stilwell Financial", "Perini", "Thomas & Betts", "Imperial Sugar", "MPS Group", "Champion Enterprises", "Granite", "National Commerce Financial", "Systemax", "Comfort Systems USA", "Greif Bros.", "Astoria Financial", "Shaw Group", "Di Giorgio", "Equifax", "Legg Mason", "ACT Manufacturing", "Level 3 Communications", "RGS Energy Group", "Universal Forest Products", "World Fuel Services", "Unova", "Arkansas Best", "GATX", "Lam Research", "Amkor Technology", "Pride International", "Polaris Industries", "Del Monte Foods", "Mercury General", "Martin Marietta Materials", "US Oncology", "Banknorth Group", "BMC Software", "Ferro", "Veritas Software", "Arch Coal", "CDI", "GenCorp", "Hibernia Corp.", "Sierra Health Services", "Atmel", "AIMCO", "Great Plains Energy", "E.W. Scripps", "Banta", "Symbol Technologies", "TMP Worldwide", "Oshkosh Truck", "Unisource Energy", "Atmos Energy", "Rock-Tenn", "Teradyne", "Questar", "American Water Works", "CSK Auto", "CKE Restaurants", "American Power Conversion", "Phillips-Van Heusen", "Cadence Design Systems", "Sports Authority", "Pier 1 Imports", "Fairchild Semiconductor Intl.", "Kemet", "Burlington Industries", "Dreyer's Grand Ice Cream", "Dimon", "Stewart & Stevenson Services", "Tecumseh Products", "Markel", "Southwest Gas", "Landstar System", "Advantica", "National Rural Utilities Cooperative", "Trans World Entertainment", "Metro-Goldwyn-Mayer", "Cytec Industries", "Standard Pacific", "Hollywood Entertainment", "Gentiva Health Services", "American Eagle Outfitters", "OneAmerica Financial", "Nvidia", "Gemstar-TV Guide International", "Acterna", "Abercrombie & Fitch", "Belo", "MGIC Investment", "Toro", "Knights of Columbus", "St. Jude Medical", "Novellus Systems", "Pro-Fac Cooperative", "Provident Financial Group", "IMS Health", "Gentek", "IT Group", "Carpenter Technology", "Electronic Arts", "Revlon", "Stein Mart", "Hub Group", "United Defense Industries", "Briggs & Stratton", "Hubbell", "Regis", "Dun & Bradstreet", "Petco Animal Supplies", "Federated Mutual Insurance", "AnnTaylor", "First National of Nebraska", "DQE", "Pacific Century Financial", "Deluxe", "Benchmark Electronics", "Amtran", "H.B. Fuller", "Men's Wearhouse", "Stewart Information Services", "Olin", "Werner Enterprises", "Comverse Technology", "Varco International", "Audiovox", "Amica Mutual Insurance", "Milacron", "Intuit", "Kimball International", "XO Communications", "Domino's", "Ocean Energy", "Massey Energy", "Texas Industries", "Riverwood Holding", "EarthLink", "Ceridian", "Union Central Life", "Phar-Mor", "Watsco", "Foamex International", "CMGI", "Pall", "Harleysville Mutual Insurance", "Tektronix", "Oglethorpe Power", "IDT", "Adobe Systems", "Alleghany", "Genzyme", "MasTec", "Genuity", "North Fork Bancorp.", "Grey Global", "Ivax", "AMC Entertainment", "On Semiconductor", "Software Spectrum", "Viasystems Group", "Georgia Gulf", "Forest Laboratories", "Perot Systems", "Trump Hotels & Casino Resorts", "FelCor Lodging", "DPL", "International Game Technology", "Blyth", "TCF Financial Corp.", "Sealy", "Standard Register", "eMerge Interactive", "Handleman", "Goody's Family Clothing", "Alexander & Baldwin", "Daisytek International", "Timberland", "American Management Systems", "C.R. Bard", "PC Connection" };
        string[] imena = { "Graciano", "Enco", "Olena", "Andreas", "Zemka", "Nikica", "Erih", "Linda", "Javorko", "Magdolna", "Kiara", "Anni", "Božidar", "Jani", "Leonora", "Janoš", "Merica", "Indira", "Himzo", "Nagib", "Denis", "Alessia", "Rosalija", "Tarin", "Naja", "Jugoslav", "Gabra", "Zagorka", "", "Santina", "Zolika", "Marko", "Ružena", "Ageta", "Kjara", "Kostadinka", "Mariela", "Hata", "Deva", "Nediljka", "Deana", "Zita", "Husein", "Sunčana", "Alojzije", "Cvijetko", "Izolda", "Rajka", "Joska", "Senita", "Vehid", "Ferruccio", "Miriam", "Marte", "Erica", "Matijka", "Tonći", "Gizela", "Suza", "Meliha", "Jandro", "Ratislav", "Arien", "Sinaja", "Zvonkica", "Mirijam", "Sedina", "Maristela", "Veli", "Milodrag", "Oleg", "Gjergj", "Kole", "Dila", "Vika", "Nevina", "Ticiana", "Emma", "Kamila", "Ana", "Aleksije", "Enes", "Katica", "Isabel", "Vasilija", "Domin", "Timon", "Kamelija", "Sanda", "Cenika", "Nikola", "Zolika", "Gracijela", "Antonijo", "Žana", "Dano", "Radenko", "Doris", "Ljuba", "Dragojla", "Mateo", "Rabija", "Marija", "Ivan", "Božica", "Šeila", "Vlatko", "Viljam", "Tera", "Arduino", "Lu", "Nevija", "Nicolas", "Anuka", "Tamara", "Sergio", "Danis", "Namka", "Tankosava", "Sloboda", "Hasan", "Gorinka", "Josko", "Lizika", "Marka", "Marija", "Osman", "Mirela", "Tripo", "Jozefina", "Denis", "Stanoje", "Nazmije", "Ešef", "Petr", "Albina", "Radovanka", "Šaban", "Evgenija", "Rahime", "Serafina", "Đorđe", "Živanka", "Adica", "Gustav", "Stojanka", "Nine", "Antonio", "Jure", "Ljerko", "Gvido", "Nicolo", "Štefek", "Krasanka", "Boriša", "Tomaž", "Dražen", "Nedjelko", "Arne", "Vehid", "Nena", "Andra", "Vanda", "Sakib", "Ajša", "Andre", "Štefka", "Nadica", "Noema", "Senida", "Krunica", "Peja", "Hasija", "Dean", "Georg", "Subha", "Veroljub", "Bartul", "Šefka", "Klotilda", "Bella", "Rukija", "Mumin", "Juliška", "Reni", "Maksimilijan", "Enija", "Mira", "Suvada", "Nezira", "Begajeta", "Muharem", "Zvonko", "Vitka", "Darij", "Biserka", "Enija", "Petrina", "Inda", "Josef", "Vladimira", "Rozana", "Divka", "Mersiha", "Ermin", "Mari", "Marija", "Dorina", "Ivan", "Umberto", "Darka", "Estella", "Annamarija", "Arlen", "Kasijan", "Anet", "Rizo", "Sadik", "Mirijam", "Sabine", "Gradimir", "Mica", "Andreja", "Fatka", "Vitorija", "Fatka", "Stijepan", "Zajko", "Dajna", "Vitoria", "Livija", "Dine", "Maximilian", "Trivo", "Nelda", "Ivoslav", "Jolanka", "Zagorka", "Aslan", "Emrah", "Miloš", "Milva", "Romano", "Keti", "Sebastijan", "Milunka", "Teofik", "Vojislav", "Nicolas", "Božimir", "Halim", "Helenka", "Romeo", "Andreas", "Sovjetka", "Renco", "Laureta", "Nolan", "Jošua", "Bare", "Hozana", "Mica", "Radek", "Ferenc", "Jessica", "Tomislav", "Pavica", "Zekira", "Dmitra", "Marija", "Sandrica", "Feti", "Sejdo", "Blagoje", "Nevena", "Tony", "Elvina", "Adelhajda", "Haidi", "Maria", "Ognjen", "Anel", "Vicka", "Erich", "Aleksandar", "Alfonzo", "Rona", "Emilijano", "Slađana", "Zemira", "Rozalinda", "Ibolya", "Đulijeta", "Hajdi", "Dražen", "Iris", "Marija", "Slavenko", "Lamia", "Nedžad", "Dmitar", "Wilhelm", "Gjergj", "Tajib", "Božica", "Sveto", "Fabian", "Stojko", "Bajro", "Mlađenka", "Vivian", "Anesa", "Kornelijo", "Iva", "Draga", "Miki", "Pierre", "Tabita", "Marlena", "Terezia", "Milenija", "Dalio", "Markica", "Boriša", "Kadri", "Federico", "Sifet", "Ratka", "Advija", "Šeherezada", "Beni", "Sejdi", "Dorjan", "Miljena", "Kole", "Wilhelm", "Rajka", "Boška", "Jonatan", "Sekana", "Iva", "Helda", "Fana", "Florija", "Lavoslav", "Cvijeta", "Mikloš", "Draženka", "Minkica", "Johana", "Kornelija", "Žarka", "Bare", "Francesco", "Ernest", "Jelisaveta", "Kristinka", "Selver", "Radan", "Ibolya", "Anes", "Tajna", "Erich", "Lazar", "Phillip", "Bedri", "Ivan", "Mio", "Dionizija", "Eugenia", "Marijuča", "Duša", "Ljuljzim", "Ragip", "Leona", "Gracia", "Fadilj", "Tiziano", "Adriana", "Ryan", "Ivan", "Velizar", "Hamida", "Bepica", "Sanio", "Mahir", "Tito", "Šefkija", "Leoni", "Kosanka", "Erwin", "Jože", "Haseda", "Redenta", "Lukrecia", "Enni", "Jožika", "Valerie", "Rahima", "Špresa", "Dženana", "Vjerana", "Miranda", "Radoslav", "Massimo", "Darja", "Armina", "Luči", "Kristin", "Edi", "Noema", "Sandrica", "Florije", "Luzarija", "Danja", "Steven", "Sejdi", "Sada", "Ehlimana", "Irna", "Susanne", "Nicholas", "Selmira", "Golub", "Hrvoslav", "Ferdi", "Husein", "Sabrina", "Jandra", "Enida", "Rajmond", "Giulio", "Evald", "Hildegarda", "Lario", "Nea", "Šaćira", "Marta", "Tažica", "Miloslava", "Gracijan", "Adele", "Patricia", "Kasijan", "Koni", "Vina", "Flora", "Maja", "Asifa", "Tvrtko", "Hamid", "Edvina", "Vukoslava", "Ivona", "Swen", "Lamia", "Fahrudin", "Đurđinka", "Bojanka", "Štefko", "Vicka", "Fikreta", "Lucka", "Abdurahman", "Cvjetan", "Elda", "Ivan", "Roberto", "Libero", "Rastislav", "Kristofor", "Mirjana", "Albertina", "Ryan", "Filippo", "Ferenc", "Luigia", "Oton", "Ema", "Ljubimka", "Vini", "Isljam", "Darija", "Nado", "Ana", "Richard", "Aramis", "Ecio", "Mara", "Cvetanka", "Erminija", "Ernesta", "Melinda", "Rok", "Lisa", "Paulina", "Guerrino", "Slava", "Friderika", "Biserka", "Natalia", "Roska", "Adi", "Orsat", "Mandalena", "Ivan", "Esmeralda", "Fabian", "Mihail", "Emilijano", "Ivonne", "Agnesa", "Doroteja", "Mito", "Jaroslava", "Živojin", "Ramzija", "Dobromir", "Iliana", "Rolanda", "Veseljko", "Trifun", "Zoltan", "Aleksa", "Tijan", "Nebojša", "Sajonara", "Kristian", "Rosina", "Zlatimir", "Antonietta", "Tedi", "Ardita", "Boštjan", "Gorjan", "Monia", "Tanasije", "Končeta", "Ernes", "Medina", "Jelislava", "Christiane", "Domina", "Husejn", "Viviana", "Biba", "Marie", "Miljko", "Tadej", "Križan", "Virđinija", "Chiara", "Svetka", "Lada", "Pijerina", "Najda", "Margarita", "Hamdo", "Ljuljeta", "Natanael", "Benko", "Val", "Isabell", "Mima", "Jago", "Andy", "Anđelo", "Bahrudin", "Davud", "Marka", "Jurijana", "Itana", "Muniba", "Jasenko", "Elvio", "Milica", "Frančeško", "Ludvig", "Paulino", "Ratko", "Nevenka", "Cvetana", "Većeslav", "Đanino", "Fran", "Nenada", "Alisa", "Megi", "Ajiša", "Zolika", "Alojz", "Tullio", "Rosina", "Zoe", "Javorko", "Rosemarie", "Ugo", "Amira", "Izabela", "Guido", "Marijanka", "Omer", "Donato", "Izvor", "Đurica", "Olena", "Svetomir", "Staža", "Fikret", "Malča", "Ratomira", "Alain", "Alison", "Sejdo", "Rusmira", "Teufik", "Dado", "Neva", "Serafin", "Pietro", "Đina", "Vale", "Fahira", "Delimir", "Ivna", "Cvitko", "Allen", "Hasiba", "Damir", "Mirabel", "Ronaldo", "Marko", "Željena", "Mera", "Stevan", "Henrik", "Ariela", "Duška", "Gašpar", "Emily", "Dano", "Leona", "Paolo", "Elda", "Franjica", "Krstina", "Ružena", "Atina", "Dedo", "Janje", "Stanimir", "Nelda", "Rasko", "Venka", "Arleta", "Vilson", "Nikoleta", "Alfonzo", "Radoja", "Ilja", "Darislav", "Haris", "Corrado", "Matij", "Mirko", "Zvonkica", "Peja", "Hadžira", "Desa", "Aliče", "Zora", "Boženka", "Josip", "Maura", "Drahuška", "Lauro", "Noel", "Slobodana", "Mirko", "Andreana", "Gligor", "Filip", "Pjero", "Antonietta", "Dada", "Hozana", "Ivko", "Irena", "Đovana", "Veselinka", "Zina", "Sandi", "Nazifa", "Emir", "Nathan", "Vatroslav", "Emanuela", "Miholjka", "Persa", "Tankosava", "Jefto", "Sanka", "Amalija", "Tomislav", "Nelli", "Dominka", "Lorela", "Nediljko", "Bella", "Džoni", "Milinko", "Borinka", "Miranda", "Anesa", "Indi", "Blaženka", "Enco", "Vicenca", "Arsenija", "Nikiša", "Guerina", "Gojislav", "Ettore", "Elvina", "Silvana", "Sajda", "Vazmoslav", "Doris", "Leonard", "Jelisaveta", "Remzije", "Prenko", "Pejo", "Nastja", "Fabjan", "Sami", "Andrica", "Gorislav", "Severino", "Almira", "Loredana", "Hasan", "Pal", "Herbert", "Kristiano", "Prena", "Romea", "Tim", "Justa", "Valerie", "Fjodor", "Jasin", "Sabina", "Martin", "Andrejana", "Alessandro", "Darka", "Persida", "Francek", "Palmina", "Doria", "Giacomo", "Frančišek", "Tune", "Ubavka", "Edgar", "Mare", "Adil", "Marijana", "Adina", "Neven", "Ivan", "Adelma", "Ernesta", "Vini", "Argeo", "Marsela", "Kadrija", "Ecija", "Ardijana", "Josip", "Arne", "Leticija", "Emra", "Poldo", "Dragomila", "Vincenc", "Karma", "Slavujka", "Lenka", "Ratimir", "Boban", "Porin", "Franka", "Sarafin", "Petrovka", "Tonica", "Lamia", "Alberta", "Nella", "Vjekoslav", "Perislava", "Franje", "Vojin", "Uma", "Ninočka", "Leonija", "Orieta", "Đenko", "Žaklina", "Semida", "Končeta", "Maja", "Tado", "Ilena", "Boženka", "Nevesin", "Cecilia", "Stjepko", "Nedjelko", "Nagib", "Bianca", "Marisa", "Hanka", "Želja", "Erminija", "Zlatimir", "Pasko", "Kol", "Đulsa", "Volga", "Đeni", "Braslav", "Elmedin", "Lovorka", "Cvijetka", "John", "Leone", "Tiziana", "Dobriša", "Isuf", "Anđa", "Abid", "Ane", "Vera", "Maksimilijan", "Judit", "Tajib", "Smiljko", "Adelija", "Stojadin", "Lindita", "Marc", "Fabijan", "Riza", "Đulijano", "Duma", "Samanta", "Talita", "Franceska", "Sladjan", "Omar", "Kažimir", "Elisabeth", "Suad", "Riza", "Janko", "Tonćika", "Venceslava", "Ružica", "Noa", "Spasenija", "Ognjenka", "Radinka", "Michael", "Nurka", "Gabro", "Svemirka", "Tino", "Korina", "Karol", "Nevzeta", "Michael", "Jakob", "Romario", "Cvita", "Vejsil", "Jasenko", "Dedo", "Ćerima", "Grozda", "Aleksandrina", "Jeroslav", "Nidia", "Kojo", "Amalija", "Amedeo", "Dubravka", "Samil", "Mulija", "Miluška", "Iboja", "Marija", "Rian", "Marijuča", "Jasenko", "Maik", "Francika", "Umija", "Rocco", "Nadica", "Slavek", "Katharina", "Age", "Lorana", "Larissa", "Cvjetko", "Tonček", "Ajna", "Normela", "Valeri", "Christopher", "Suza", "Mirnes", "Kamenko", "Seni", "Sanjica", "Zoja", "Aneli", "Anabella", "Stjepan", "Franjica", "Marlena", "Šehida", "Hanija", "Gjurgjica", "Lean", "Duje", "Rita", "Mlađan", "Tessa", "Branislava", "Erža", "Korina", "Gena", "Stephanie", "Bogomir", "Ramadan", "Danil", "Samuel", "Milo", "Slavna", "Vanda", "Ljubomirka", "Dragoslav", "Kole", "Vasva", "Vuk", "Mire", "Agustin", "Aleksandar", "Sofija", "Spasoje", "Damirka", "Miron", "Evelyn", "Pablo", "Kristi", "Elfat", "Moravka", "Emka", "Josipka", "Biba", "Sanijel", "Caterina", "Eleni", "Eugenija", "Tuna", "Milorad", "Evica", "Elmira", "Mea", "Vanja", "Jelisava", "Daria", "Ana", "Andrejana", "Rizah", "Šerife", "Lahorka", "Nevenka", "Marcella", "Svetko", "Fulvio", "Ondina", "Raoul", "Krist", "Mandica", "Risto", "Narda" };
        string[] prezimena = { "Cvikl", "Sambolek", "Križovan", "Šilješ", "Smolej", "Šergo", "Eđed", "Stocovaz", "Motik", "Čabraja", "Jareš", "Volk", "Maršanić", "Batagelj", "Radusinović", "Rossi", "Muharemović", "Milunović", "Poleksić", "Jurić", "Milneršić", "Vrcelj", "Kodba", "Radušević", "Jendrašic", "Dunđer", "Rakin", "Vodnik", "Kuhada", "Štibel", "Šimir", "Korostilj", "Zenkić", "Parezanović", "Delinc", "Lalin", "Koboević", "Srček", "Kauković", "Brandić", "Sadžak", "Cizel", "Šusterajter", "Kunetić", "Baletin", "Hvasta", "Pavela", "Ličinić", "Džemailji", "Jočić", "Briševac", "Čoban", "Kerečeni", "Šimović", "Mušić", "Cifrić", "Bradica", "Montan", "Šneller", "Bohm", "Gložić", "Juran", "Uremović", "Gradinac", "Tomašinec", "Zeba", "Mađerčić", "Husak", "Kurpes", "Viličić", "Škrmeta", "Bilić", "Zlodre", "Pevac", "Lugarec", "Mrđanović", "Zenić", "Baričak", "Prstac", "Ugulin", "Čurćić", "Rančić", "Levaj", "Ilakovac", "Kavalir", "Zidanić", "Biskupović", "Krejči", "Japec", "Sebeledi", "Havaši", "Ćustić", "Dajević", "Šurbek", "Moškov", "Čizmok", "Falnoga", "Bartol", "Mrkus", "Grilek", "Pintera", "Prenner", "Kette", "Gavranović", "Graonić", "Tajić", "Smola", "Librić", "Ferenci", "Eklić", "Škrlac", "Salihbegović", "Mudrinjak", "Cukor", "Lela", "Hobor", "Fičur", "Šegerec", "Barlafa", "Fuštin", "Lojkić", "Labavić", "Brajenović", "Rorić", "Hajdinac", "Fekonja", "Zajić", "Opašić", "Bazijak", "Makvić", "Korušić", "Mevželj", "Panđa", "Delimar", "Šimek", "Plehati", "Serezlija", "Vinceković", "Marš", "Zenuni", "Šakoronja", "Novoselec", "Matuha", "Nuriši", "Miklić", "Kernjus", "Ogorevc", "Mihalec", "Bačac", "Kastelc", "Brizić", "Korlatović", "Hip", "Matoković", "Čorković", "Arapinac", "Hajtić", "Kunce", "Radmilović", "Pucej", "Ladenlajter", "Teči", "Malčić", "Lomnicki", "Šušljek", "Arelić", "Kečak", "Javornik", "Repić", "Tejeci", "Paliska", "Šišejković", "Draganjac", "Pejnović", "Marag", "Muhadri", "Muranić", "Grantverger", "Ille", "Šendula", "Batestin", "Karadžić", "Pruže", "Baras", "Črnjak", "Franješević", "Pelengić", "Nezirević", "Škarda", "Brahović", "Stanojević", "Prugo", "Ivanošić", "Šebenik", "Bivolčević", "Kuzmić", "Karlik", "Skorušek", "Savi", "Krpanec", "Kešic", "Sekanić", "Marak", "Antićev", "Vodopija", "Klečina", "Damjankov", "Brkopac", "Grubissa", "Ivak", "Sotošek", "Bazijanac", "Orgulan", "Mihel", "Iđoški", "Antolković", "Frajzman", "Rosić", "Bujanec", "Sekulić", "Kalozi", "Preksavec", "Montag", "Kulašević", "Benedek", "Bedjić", "Lech", "Petronio", "Grubačević", "Avdi", "Genter", "Kolđeraj", "Horg", "Čanžek", "Corn", "Zaspan", "Skok", "Čadež", "Kasanić", "Cvjetojević", "Katančević", "Branšteter", "Mehmedbegović", "Plepelić", "Stern", "Munić", "Čalić", "Kapčević", "Radeka", "Lavrenčić", "Hakenberg", "Hribljan", "Gado", "Rujak", "Moreti", "Žilović", "Volić", "Đokanović", "Supan", "Stanimirović", "Birčić", "Ružojčić", "Lukin", "Ferenđa", "Kolobara", "Puović", "Platušić", "Hasanović", "Pogledić", "Tuđan", "Srebrnjak", "Andlar", "Kakuk", "Podubski", "Pisker", "Šljukić", "Jakrlin", "Kolonić", "Kljusurić", "Sabljak", "Paurić", "Koranić", "Ulafić", "Preka", "Šuvajić", "Coban", "Brnjevarac", "Garba", "Ćatović", "Ramaja", "Bucaj", "Rade", "Probojčević", "Peretin", "Borovičkić", "Kotrulja", "Jerosimić", "Tkalčić", "Katarin", "Strman", "Pocedulić", "Kelebuh", "Ameti", "Jaran", "Benja", "Korkutović", "Vitori", "Čaplja", "Štefičić", "Djaković", "Bedenic", "Pilaković", "Boranić", "Osmakčić", "Werner", "Rogošić", "Čerević", "Mazavac", "Čizmok", "Kvesić", "Podkrajac", "Glas", "Pindrić", "Stern", "Gorjanac", "Svečnjak", "Hažić", "Samošćanec", "Laus", "Slivac", "Umnik", "Kušina", "Markeš", "Klanac", "Paček", "Kozarec", "Boras", "Gorajščan", "Srkoč", "Nakić", "Juratić", "Fiedler", "Drobnak", "Božić", "Bajči", "Pažameta", "Božičanin", "Mihajlija", "Božanić", "Oblić", "Drljepan", "Mahin", "Grabušić", "Cerenko", "Ošaben", "Hrkalović", "Krupa", "Kolobara", "Palačić", "Ivanček", "Smekal", "Šoštarić", "Dragšić", "Hovorka", "Jeić", "Galko", "Crmarić", "Kotaršćak", "Desin", "Despinić", "Bećar", "Štajfer", "Delić", "Pejazić", "Đurđevac", "Mohila", "Balaj", "Bodor", "Tretnjak", "Kusak", "Pintauer", "Gajan", "Klaneček", "Mataija", "Pačar", "Bogojević", "Šenija", "Drčec", "Djorić", "Oslić", "Šaflin", "Pozojević", "Ojdenić", "Battistutta", "Brliček", "Gračaković", "Santro", "Golubovac", "Opšivač", "Stanilović", "Pavičin", "Mohor", "Bajraj", "Cikoš", "Kelvišer", "Haliti", "Nikoletić", "Ploj", "Šereg", "Perše", "Mavretić", "Villanovich", "Podubski", "Pavina", "Čalaković", "Mihalković", "Hubanić", "Požgajec", "Seleši", "Prežgaj", "Šturica", "Donat", "Metulj", "Grdović", "Bajama", "Aldobašić", "Doring", "Stolfa", "Bastaja", "Čuraj", "Saliu", "Baltić", "Ujdurović", "Karaman", "Kučinić", "Pokopac", "Osmoričić", "Karažija", "Pucelj", "Ošlaj", "Glogović", "Jamer", "Marelj", "Banovčić", "Šprihal", "Grbenić", "Srdanović", "Pažin", "Jotić", "Zetica", "Benger", "Bodlović", "Leiner", "Bežovan", "Jeran", "Nevžala", "Gregurec", "Omelić", "Lučevnjak", "Debeljački", "Bertalan", "Spasovski", "Raimund", "Kapelac", "Smolčec", "Jandrašec", "Loje", "Foškulo", "Pildek", "Ožvalt", "Šveda", "Ljubenko", "Efinger", "Ber", "Pečić", "Sohor", "Božićević", "Dobri", "Mikulić", "Pajduh", "Čučković", "Baketarić", "Zlošilo", "Harmat", "Pivčević", "Biško", "Lisak", "Otorepec", "Zorinić", "Đumbir", "Kurobasa", "Kajtazović", "Suhin", "Dobroević", "Kljusurić", "Sandrovac", "Čehovski", "Verbić", "Liković", "Flojhar", "Huđber", "Voskion", "Mišević", "Hašpl", "Vakufac", "Sobin", "Kordej", "Ipsa", "Mastilica", "Sajković", "Fotović", "Lapačina", "Smojvir", "Malačić", "Crnko", "Noci", "Golemac", "Ovčarić", "Mušicki", "Umolac", "Vacka", "Jantoš", "Črnelić", "Makk", "Vuraić", "Dovičin", "Viali", "Jančić", "Osojnički", "Klasić", "Kozmar", "Matoušek", "Martinec", "Sančanin", "Liklin", "Spivak", "Steklar", "Čunko", "Lolić", "Oštarčević", "Vidulić", "Turopolec", "Zimmermann", "Firi", "Gojmerac", "Jurkotić", "Simat", "Perišin", "Brener", "Parlov", "Smailagić", "Strugar", "Pandur", "Pleh", "Sandri", "Kendić", "Bešić", "Budinšćak", "Bubičić", "Cico", "Pavšić", "Medan", "Zagoranski", "Kalašić", "Toplišnjak", "Pavičar", "Kohut", "Dobošić", "Orihovac", "Prenković", "Floigl", "Điković", "Batričević", "Barunović", "Malević", "Lavrenčić", "Elpeza", "Božoki", "Brnelić", "Futač", "Đuričić", "Strizrep", "Topolko", "Majkovčan", "Pilošta", "Cundeković", "Sokić", "Krutak", "Smek", "Panjkret", "Glokević", "Vnuk", "Cesarik", "Miškolci", "Vuko", "Žumbar", "Vardić", "Saratlić", "Stegnjaić", "Demšer", "Bartolec", "Jarki", "Adžaip", "Salama", "Pulin", "Cekuš", "Poldrugač", "Zgonjanin", "Matičić", "Čeak", "Šajin", "Miholček", "Žuklić", "Žitković", "Lošonc", "Šariri", "Szegi", "Cape", "Vahtarić", "Vodomin", "Bolun", "Herster", "Salma", "Mrsić", "Draganjac", "Žugčić", "Pavičić", "Koražija", "Joh", "Malik", "Ćukac", "Santl", "Đonlić", "Stoković", "Črnec", "Justinić", "Puž", "Kulašević", "Đebrić", "Riđić", "Halilagić", "Hofmann", "Halavanić", "Kavaš", "Šljivečka", "Batinić", "Behtanić", "Cipci", "Delač", "Ištvanek", "Ezer", "Adilji", "Vejnović", "Juraš", "Antolić", "Lustek", "Popić", "Jurjak", "Pende", "Nađvinski", "Spasić", "Ljubenković", "Fiamengo", "Cvetkovič", "Šimir", "Nečemer", "Gareljić", "Oštadal", "Kunstl", "Lučić", "Bojanin", "Gluška", "Černac", "Lendl", "Manoić", "Matančević", "Jerger", "Biljuš", "Smoljić", "Maltarski", "Udović", "Jankov", "Šimunaj", "Džanić", "Zjalić", "Rusek", "Jasić", "Sardot", "Sajtlik", "Degoricija", "Gajger", "Mrkus", "Bureš", "Mikacinić", "Jakopanec", "Hozdić", "Štrbenac", "Šundov", "Vragolov", "Jilk", "Černić", "Dubinko", "Sladonja", "Govedarović", "Posavec", "Špiljak", "Pipus", "Krekić", "Prskavac", "Krošnjar", "Šuljug", "Kišantal", "Igladić", "Mlatković", "Banoci", "Buzuk", "Tepurić", "Osonički", "Mijaljica", "Klampfl", "Đitko", "Laginja", "Zulin", "Bonassin", "Antičević", "Bartoloti", "Škopić", "Runje", "Čubelj", "Čićak", "Turajlić", "Milčec", "Linar", "Hanzelik", "Peters", "Garilović", "Valentičević", "Divšić", "Harambašić", "Ukalović", "Repe", "Češljić", "Mišmaš", "Malec", "Rago", "Kubat", "Generalić", "Poletar", "Mrinjek", "Mezeji", "Mulja", "Dimnjašević", "Midžić", "Blačić", "Šklempe", "Elblinger", "Karjaković", "Posavec", "Hunski", "Nunić", "Kamenjak", "Hudina", "Lipej", "Kočić", "Rell", "Pisarović", "Šudar", "Beronić", "Matuzović", "Šibalić", "Piskić", "Šalov", "Kada", "Mihajlov", "Đuriš", "Horvačanović", "Paljuh", "Šanje", "Lojkić", "Paštrović", "Fried", "Teofanović", "Tomečić", "Miklaužić", "Čakan", "Sfarčić", "Fiuri", "Boljfetić", "Maležić", "Đurinjak", "Pedišić", "Sudetić", "Šeat", "Međed", "Hajplan", "Omahić", "Rešček", "Brumec", "Trojka", "Sretenović", "Šekelja", "Trtica", "Erhat", "Milašinović", "Tuka", "Dolinar", "Belobradić", "Rigljan", "Birčić", "Hajsan", "Vacka", "Pošta", "Burečić", "Sturnela", "Đuras", "Bura", "Požarić", "Čelebić", "Tubaković", "Sobočan", "Kečak", "Šaronja", "Đordić", "Vagjon", "Klaus", "Juvan", "Turšić", "Makarin", "Mujčić", "Prljević", "Por", "Moka", "Sente", "Kojundžija", "Bečirević", "Pratnemer", "Greiner", "Aličić", "Šupek", "Grego", "Činčurak", "Bondža", "Buktenica", "Mišura", "Husarić", "Gligo", "Koščak", "Srbljan", "Strahinić", "Šegedin", "Đulabić", "Tecilazić", "Kuz", "Akalović", "Mejovšek", "Prepunić", "Šofkić", "Korovljević", "Kišiček", "Makarić", "Horčićka", "Robak", "Budna", "Zobunđija", "Mihok", "Kočar", "Pinko", "Vertuš", "Šnajder", "Šivalec", "Frič", "Pajaziti", "Vabik", "Kostovski", "Škojc", "Tiban", "Mrgudić", "Berljak", "Zarezovski", "Žegura", "Dvojak", "Ćutić", "Kuvačić", "Gantar", "Škatar", "Boršćak", "Židanić", "Drugčević", "Cilar", "Ašperger", "Stambolić", "Zilinski", "Čenan", "Gavlik", "Cicnjak", "Kausal", "Čikota", "Rakitić", "Colnarić", "Milko", "Feist", "Horvatuš", "Renac", "Doutlik", "Krošnjak", "Buždon", "Stornoga", "Geušić", "Mauser", "Beštak", "Butara", "Kučan", "Vlajsović", "Valušek", "Gojko", "Kamenjaš", "Ćerdić", "Đikić", "Huten", "Barjamović", "Koprolčec", "Negotić", "Ilišević", "Hrković", "Jakovašić", "Vrtačić", "Strižak", "Ivančir", "Šćetar", "Varda", "Kranjčec", "Cajner", "Rodi", "Šikanja", "Zafron", "Konječić", "Sumpor", "Kajtazi", "Ziberi", "Dapas", "Udiković", "Džomba", "Šever", "Osvald", "Šolja", "Peškura", "Bjelokapić", "Oršić", "Divanović", "Štajner", "Šiškov", "Bačmaga", "Ilinović", "Joo", "Špeljak", "Betica", "Pajdak", "Sindičić", "Klaričić", "Duvandžija", "Višaticki", "Doljankić", "Gjugja", "Turda", "Šuto", "Bjelac", "Ginder", "Kiš", "Čuni", "Aradski", "Buntak", "Alvađ", "Vincek", "Komšo", "Ajder", "Leutar", "Jakopec", "Kočić", "Plazzeriano", "Marijančić", "Koncul", "Špringman", "Engler", "Panović", "Jurlin", "Bakai", "Halapir", "Gašparin", "Bombek", "Kusuran", "Jagec", "Ljubica", "Kršija", "Glibić", "Frajhaut", "Obradovac", "Hamedović", "Krenus", "Kobasić", "Dološić" };

        public GeneratorPodatki()
        {
            InitializeComponent();
        }

        private void GeneratorPodatki_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Time;
            dateTimePicker1.ShowUpDown = true;
            dateTimePicker2.Format = DateTimePickerFormat.Time;
            dateTimePicker2.ShowUpDown = true;
            dateTimePicker3.Format = DateTimePickerFormat.Time;
            dateTimePicker3.ShowUpDown = true;
            dateTimePicker4.Format = DateTimePickerFormat.Time;
            dateTimePicker4.ShowUpDown = true;
            dateTimePicker5.Format = DateTimePickerFormat.Custom;
            dateTimePicker5.CustomFormat = "yyyy-MM-dd HH:mm";
            dateTimePicker6.Format = DateTimePickerFormat.Custom;
            dateTimePicker6.CustomFormat = "yyyy-MM-dd HH:mm";
            dateTimePicker7.Format = DateTimePickerFormat.Time;
            dateTimePicker7.ShowUpDown = true;
            dateTimePicker8.Format = DateTimePickerFormat.Time;
            dateTimePicker8.ShowUpDown = true;
            updateData();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
                checkedListBox1.SetItemChecked(i, true);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
                checkedListBox1.SetItemChecked(i, false);
        }

        private void updateData()
        {
            checkedListBox1.Items.Clear();
            string sql2 = "SELECT * FROM firma";
            var command2 = new SQLiteCommand(sql2, db.GetConnection());
            using (SQLiteDataReader read = command2.ExecuteReader())
            {
                while (read.Read())
                {
                    checkedListBox1.Items.Add(read["naziv"].ToString());
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Random rnd = new Random();
                dateTimePicker1.Value = new DateTime(2000, 1, 1, dateTimePicker1.Value.Hour, dateTimePicker1.Value.Minute, dateTimePicker1.Value.Second);
                dateTimePicker2.Value = new DateTime(2000, 1, 1, dateTimePicker2.Value.Hour, dateTimePicker2.Value.Minute, dateTimePicker2.Value.Second);
                dateTimePicker3.Value = new DateTime(2000, 1, 1, dateTimePicker3.Value.Hour, dateTimePicker3.Value.Minute, dateTimePicker3.Value.Second);
                dateTimePicker4.Value = new DateTime(2000, 1, 1, dateTimePicker4.Value.Hour, dateTimePicker4.Value.Minute, dateTimePicker4.Value.Second);

                var pocetak = (dateTimePicker2.Value) - (dateTimePicker1.Value);
                if ((dateTimePicker2.Value) - (dateTimePicker1.Value) < TimeSpan.Zero)
                    return;
                if ((dateTimePicker4.Value) - (dateTimePicker3.Value) < TimeSpan.Zero)
                    return;


                string sql = "INSERT INTO firma (naziv, ulazPocetak, ulazKraj, izlazPocetak, izlazKraj) VALUES ";
                bool first = true;
                for (int i = 0; i < Int32.Parse(textBox1.Text); i++)
                {



                    int razlikaMinuta = (dateTimePicker2.Value.Hour - dateTimePicker1.Value.Hour) * 60 + dateTimePicker2.Value.Minute - dateTimePicker1.Value.Minute;
                    int randMinute = rnd.Next(0, razlikaMinuta / 2);
                    DateTime ulazPocetak = new DateTime((new TimeSpan(0, rnd.Next(0, razlikaMinuta / 2), 0) + (dateTimePicker1.Value - new DateTime(0))).Ticks);
                    DateTime ulazKraj = new DateTime((new TimeSpan(0, rnd.Next(0, razlikaMinuta / 2) + razlikaMinuta / 2, 0) + (dateTimePicker1.Value - new DateTime(0))).Ticks);

                    int razlikaMinuta2 = (dateTimePicker4.Value.Hour - dateTimePicker3.Value.Hour) * 60 + dateTimePicker4.Value.Minute - dateTimePicker3.Value.Minute;
                    int randMinute2 = rnd.Next(0, razlikaMinuta2 / 2);
                    DateTime izlazPocetak = new DateTime((new TimeSpan(0, rnd.Next(0, razlikaMinuta2 / 2), 0) + (dateTimePicker3.Value - new DateTime(0))).Ticks);
                    DateTime izlazKraj = new DateTime((new TimeSpan(0, rnd.Next(0, razlikaMinuta2 / 2) + razlikaMinuta2 / 2, 0) + (dateTimePicker3.Value - new DateTime(0))).Ticks);


                    if (!first) sql += ", ";
                    sql += "('" + firmeImena[rnd.Next(999)] + "','" + ulazPocetak.ToString("HH:mm") + "','" + ulazKraj.ToString("HH:mm") + "','" + izlazPocetak.ToString("HH:mm") + "','" + izlazKraj.ToString("HH:mm") + "')";
                    first = false;

                }
                sql += ";";
                richTextBox1.Text = sql;
                var command = new SQLiteCommand(sql, db.GetConnection());
                command.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Greška pri unosu");
            }
            updateData();


        }

        private void dateTimePicker6_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            string sql = "INSERT INTO zaposlenik (ime, prezime, firma) VALUES ";
            bool first = true;
            for (int i = 0; i < Int32.Parse(textBox2.Text); i++)
            {
                if (!first) sql += ", ";
                sql += "('" + imena[rnd.Next(999)] + "','" + prezimena[rnd.Next(999)] + "'," + (rnd.Next(checkedListBox1.CheckedIndices.Count) + 1) + ")";
                first = false;
            }
            sql += ";";
            richTextBox1.Text = sql;
            var command = new SQLiteCommand(sql, db.GetConnection());
            command.ExecuteNonQuery();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (dateTimePicker6.Value.Ticks - dateTimePicker5.Value.Ticks <= 0)
                {
                    MessageBox.Show("Greška pri unosu");
                    return;
                }
                Random rnd = new Random();
                long diff = dateTimePicker6.Value.Ticks - dateTimePicker5.Value.Ticks;


                string sql2 = "SELECT COUNT(*) FROM zaposlenik";
                var command2 = new SQLiteCommand(sql2, db.GetConnection());
                int count = Int32.Parse(command2.ExecuteScalar().ToString()) + 1;



                string sql = "INSERT INTO radniZapis (zaposlenik, vrijeme) VALUES ";



                if (checkBox2.Checked)
                {

                    int amount = 0;
                    DateTime tempDate = dateTimePicker5.Value.Date;
                    while (dateTimePicker6.Value > tempDate)
                    {
                        if (tempDate.DayOfWeek != DayOfWeek.Sunday || tempDate.DayOfWeek != DayOfWeek.Saturday)
                            amount++;
                        tempDate = tempDate.AddDays(1);
                    }
                    for (int zaposlenikID = 1; zaposlenikID < count; zaposlenikID++)
                        for (int i = 0; i < amount; i++)
                        {
                            if (dateTimePicker5.Value.AddDays(i).DayOfWeek == DayOfWeek.Sunday || dateTimePicker5.Value.AddDays(i).DayOfWeek == DayOfWeek.Saturday)
                                continue;

                            DateTime dt = dateTimePicker5.Value.AddDays(i);
                            if (checkBox1.Checked)
                            {

                                dt = new DateTime(dt.Year, dt.Month, dt.Day);
                                dt = dt.AddSeconds(rnd.Next(Int32.Parse(textBox4.Text) * 60 * 2) - Int32.Parse(textBox4.Text) * 60);
                                dt = dt.AddSeconds(dateTimePicker7.Value.Second);
                                dt = dt.AddMinutes(dateTimePicker7.Value.Minute);
                                dt = dt.AddHours(dateTimePicker7.Value.Hour);
                                sql += "(" + zaposlenikID + ",'" + dt.ToString("yyyy-MM-ddTHH:mm:ss") + "'),";

                                DateTime dt2 = new DateTime(dt.Year, dt.Month, dt.Day);
                                dt2 = dt2.AddSeconds(rnd.Next(Int32.Parse(textBox4.Text) * 60 * 2) - Int32.Parse(textBox4.Text) * 60);
                                dt2 = dt2.AddSeconds(dateTimePicker8.Value.Second);
                                dt2 = dt2.AddMinutes(dateTimePicker8.Value.Minute);
                                dt2 = dt2.AddHours(dateTimePicker8.Value.Hour);


                                sql += "(" + zaposlenikID + ",'" + dt2.ToString("yyyy-MM-ddTHH:mm:ss") + "')";
                            }
                            else
                            {
                                dt = (dt.Date - dt.TimeOfDay).AddSeconds(rnd.Next(24 * 60 * 60 - 1));
                                sql += "(" + zaposlenikID + ",'" + dt.ToString("yyyy-MM-ddTHH:mm:ss") + "'),";

                                DateTime dt2 = new DateTime(dt.Year, dt.Month, dt.Day).AddSeconds(rnd.Next(24 * 60 * 60 - 1));
                                sql += "(" + zaposlenikID + ",'" + dt2.ToString("yyyy-MM-ddTHH:mm:ss") + "')";
                            }


                            if (zaposlenikID != count - 1 || i != amount -1) sql += ", ";
                        }
                }

                else
                {
                    for (int i = 0; i < Int32.Parse(textBox3.Text); i++)
                    {

                        DateTime dt = new DateTime((long)(rnd.NextDouble() * diff) + dateTimePicker5.Value.Ticks);
                        int zaposlenikID = rnd.Next(count) + 1;
                        if (checkBox1.Checked)
                        {

                            dt = new DateTime(dt.Year, dt.Month, dt.Day);
                            dt = dt.AddSeconds(rnd.Next(Int32.Parse(textBox4.Text) * 60 * 2) - Int32.Parse(textBox4.Text) * 60);
                            dt = dt.AddSeconds(dateTimePicker7.Value.Second);
                            dt = dt.AddMinutes(dateTimePicker7.Value.Minute);
                            dt = dt.AddHours(dateTimePicker7.Value.Hour);


                            sql += "(" + zaposlenikID + ",'" + dt.ToString("yyyy-MM-ddTHH:mm:ss") + "'),";

                            DateTime dt2 = new DateTime(dt.Year, dt.Month, dt.Day);
                            dt2 = dt2.AddSeconds(rnd.Next(Int32.Parse(textBox4.Text) * 60 * 2) - Int32.Parse(textBox4.Text) * 60);
                            dt2 = dt2.AddSeconds(dateTimePicker8.Value.Second);
                            dt2 = dt2.AddMinutes(dateTimePicker8.Value.Minute);
                            dt2 = dt2.AddHours(dateTimePicker8.Value.Hour);


                            sql += "(" + zaposlenikID + ",'" + dt2.ToString("yyyy-MM-ddTHH:mm:ss") + "')";
                        }
                        else
                        {


                            sql += "(" + zaposlenikID + ",'" + dt.ToString("yyyy-MM-ddTHH:mm:ss") + "'),";

                            DateTime dt2 = new DateTime(dt.Year, dt.Month, dt.Day).AddSeconds(rnd.Next(24 * 60 * 60 - 1));
                            sql += "(" + zaposlenikID + ",'" + dt2.ToString("yyyy-MM-ddTHH:mm:ss") + "')";
                        }

                        if (i != Int32.Parse(textBox3.Text) - 1) sql += ", ";

                    }
                }
                sql += ";";
                richTextBox1.Text = sql;
                var command = new SQLiteCommand(sql, db.GetConnection());
                command.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Greška pri unosu");
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
                textBox3.Enabled = true;
            else
                textBox3.Enabled = false;

        }
    }
}