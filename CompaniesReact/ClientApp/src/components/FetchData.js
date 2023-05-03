import React, { Component } from 'react';

export class FetchData extends Component {
  static displayName = FetchData.name;

  constructor(props) {
    super(props);
      this.state = { branches: [], loading: true };
  }

  componentDidMount() {
    this.populateWeatherData();
  }

  static renderBranchesTable(branches) {
    return (
      <table className="table table-striped" aria-labelledby="tableLabel">
        <thead>
          <tr>
            <th>Branch</th>
            <th>Company branch</th>
            <th>Company group</th>
            <th>Related branches</th>
          </tr>
        </thead>
        <tbody>
          {branches.map(branche =>
            <tr key={branche.id}>
              <td>{branche.name}</td>
              <td>{branche.company.name}</td>
                  <td>{branche.company.binarySign}</td>
                  <td>{branches.map(x => {
                      if (x.company.binarySign === branche.company.binarySign
                            && x.id != branche.id) {
                          return (<p>{x.name}</p>)
                      }
                  })}</td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : FetchData.renderBranchesTable(this.state.branches);

    return (
      <div>
        <h1 id="tableLabel">Companies branches</h1>
        {contents}
      </div>
    );
  }

  async populateWeatherData() {
      const response = await fetch('companiesbranches');
    const data = await response.json();
    this.setState({ branches: data, loading: false });
  }
}
