import React, { Component } from 'react';

export class ExportButton extends Component {

    constructor(props) {
        super(props);                
    }

    exportYamlFile = () => {       

        console.log(this.props.elements)

        const requestOptions = {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({
                elements: this.props.elements
            })
        }

        fetch('file', requestOptions)
            .then(response => {
                response.blob().then(blob => {
                    let url = window.URL.createObjectURL(blob);
                    let a = document.createElement('a');
                    a.href = url;
                    a.download = 'export.yaml';
                    a.click();
                })
                    .catch({
                        function() {
                            console.log("error")
                        }
                    });
            });
    }

    render() {
        return (
            <div>
                <button onClick={this.exportYamlFile}>Save & Export</button>

            </div>
        );
    }


}

