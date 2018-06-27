//Initialize AngularJS
var ngApp = angular.module('myNgApp', []);
ngApp.controller('myController', function ($scope,$http) {
    $scope.load = function () {
        //Load color palettes
        $scope.BandAPalette = bandColors.ValidBandAColors;
        $scope.BandBPalette = bandColors.ValidBandBColors;
        $scope.BandCPalette = bandColors.ValidBandCColors;
        $scope.BandDPalette = bandColors.ValidBandDColors;

        //Load Resistor Image
        var svgDoc = document.getElementById("Ohm-alphasvg");

        // It's important to add an load event listener to the object,
        // as it will load the svg doc asynchronously
        svgDoc.addEventListener("load", function () {

            // get the inner DOM of alpha.svg
            var svgInnerDoc = svgDoc.contentDocument;
            // get all the four bands
            $scope.bands = [svgInnerDoc.getElementById("BandA"),
            svgInnerDoc.getElementById("BandB"),
             svgInnerDoc.getElementById("BandC"),
            svgInnerDoc.getElementById("BandD")];

            // add behaviour
            $scope.bands[0].addEventListener("mousedown", $scope.bandMouseDown, false);
            $scope.bands[1].addEventListener("mousedown", $scope.bandMouseDown, false);
            $scope.bands[2].addEventListener("mousedown", $scope.bandMouseDown, false);
            $scope.bands[3].addEventListener("mousedown", $scope.bandMouseDown, false);

            $scope.bands[0].colorSet = false;
            $scope.bands[1].colorSet = false;
            $scope.bands[2].colorSet = false;
            $scope.bands[3].colorSet = false;

        }, false);
    }
    
   //Toggle Color palette on click
    $scope.bandMouseDown = function ($event) {
        $scope.selectedBand = $event.target;
        var leftPosition = $scope.getLeftOffset($scope.selectedBand),
         topPosition = $scope.getTopOffset($scope.selectedBand);
        $scope.paletteShowToggle($scope.selectedBand, null, leftPosition, topPosition);
        
    }

    //Set color from Palette
    $scope.SetColor = function ($event) {
        var selectedColor = $event.currentTarget.className;
        $scope.selectedBand.style.fill = selectedColor;
        $scope.paletteShowToggle(null, $event.currentTarget.parentElement, null, null);
        $scope.selectedBand.color = selectedColor;
        $scope.selectedBand.colorSet = true;

        var ohmvalue;
        //Get ohmvalue when all the bands are colored
        if ($scope.bands[0].colorSet == true && $scope.bands[1].colorSet == true && $scope.bands[2].colorSet == true && $scope.bands[3].colorSet == true) {
            $scope.getOhmValue();
        }
    }

    //Get ohm value. Call the Web API to get value
    $scope.getOhmValue = function () {
        //call apI
        var value;
        var colorsParam = $scope.bands[0].color + '/' + $scope.bands[1].color + '/' + $scope.bands[2].color + '/' + $scope.bands[3].color
        $http.get('/api/OhmValue/' + colorsParam).then(function success(response) {
            value = response.data;
            $scope.OhmValue = value + ' Ohms';
        }, function myError(response) {
            alert(response.statusText);
        });
    }

   
    //Toggle visibility of color palette
    $scope.paletteShowToggle = function (clickedElement, palette, leftPosition, topPosition) {
        var x = palette;
        if (palette == null && palette == undefined && clickedElement != null && clickedElement != undefined) {
            $scope.HideAllPalettes();
            if (clickedElement.id == "BandA")
                x = document.getElementById("Ohm-Color-Palette-Band-A");
            if (clickedElement.id == "BandB")
                x = document.getElementById("Ohm-Color-Palette-Band-B");
            if (clickedElement.id == "BandC")
                x = document.getElementById("Ohm-Color-Palette-Band-C");
            if (clickedElement.id == "BandD")
                x = document.getElementById("Ohm-Color-Palette-Band-D");
        }
        if (x.style.visibility === "hidden") {
            x.style.visibility = "visible";
        } else {
            x.style.visibility = "hidden";
        }
        if (leftPosition != null && topPosition != null) {
            x.style.left = leftPosition + "px";
            x.style.top = (topPosition) + "px";
        }
    }

    //Hide all color palettes
    $scope.HideAllPalettes = function () {
        var x = document.querySelectorAll(".Palette");
        var i,y;
        for (i = 0; i < x.length;i++)
        {
            y = x[i];
            y.style.visibility = "hidden";
        }
    }

    //Get palette left position
    $scope.getLeftOffset = function (targetElement) {
        var bodyRect = document.body.getBoundingClientRect();
        if (targetElement != null) {
            var elemRect = targetElement.getBoundingClientRect();
            return (elemRect.left - bodyRect.left);
        }
        return 0;
    }

    //Get palette top position
    $scope.getTopOffset = function (targetElement) {
        var bodyRect = document.body.getBoundingClientRect();
        if (targetElement != null) {
            var elemRect = targetElement.getBoundingClientRect();
            return (elemRect.top - bodyRect.top);
        }
        return 0;
    }

    
});