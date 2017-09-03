<?php 
    Header('Content-type: text/xml');
    echo '<?xml version="1.0" encoding="UTF-8"?>
';
?>
<urlset xmlns="http://www.sitemaps.org/schemas/sitemap/0.9">
    <url>
        <loc>http://www.zeeping.com/</loc>
        <lastmod>2017-03-01</lastmod>
        <changefreq>weekly</changefreq>
        <priority>0.9</priority>
    </url>
    <url>
        <loc>http://www.zeeping.com/FAQ</loc>
        <lastmod>2017-08-20</lastmod>
        <changefreq>weekly</changefreq>
        <priority>0.7</priority>
    </url>
    <url>
        <loc>http://zeeping.com/customer/support.php</loc>
        <lastmod>2017-07-19</lastmod>
        <changefreq>weekly</changefreq>
        <priority>0.8</priority>
    </url>
    <url>
        <loc>http://zeeping.com/customer/login.php</loc>
        <lastmod>2017-06-20</lastmod>
        <changefreq>weekly</changefreq>
        <priority>0.7</priority>
    </url>
    <?php
        // Echo Menu and Page
        $Menus = getAllMenuWeb();
        foreach($Menus as $Menu)
        {
            echo '<url>
                <loc>http://www.zeeping.com/' . $Menu["link"] .'/</loc>
                <lastmod>2017-03-01</lastmod>
                <changefreq>monthly</changefreq>
                <priority>0.8</priority>
            </url>
            ';
        }
        // Echo Products
        $Products = getNewProducts(100);
        foreach($Products as $Product)
        {
            echo '<url>
                <loc>http://www.zeeping.com/' . $Product["linkProduct"] .'/</loc>
                <lastmod>' . date_format(date_create($Product["createdDate"]), "Y-m-d") . '</lastmod>
                <changefreq>weekly</changefreq>
                <priority>' . (($Product["isFeaturedProduct"] == true) ? "1.0" : "0.69"). '</priority>
            </url>
            ';
        }
   ?>
</urlset>