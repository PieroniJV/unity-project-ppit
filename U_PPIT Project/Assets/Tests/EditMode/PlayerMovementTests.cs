using NUnit.Framework;
using UnityEngine;

public class PlayerMovementTests
{
    [Test]
    public void PlayerMovementYAxisPositionTest()
    {
        // Arrange
        GameObject testPlayer = new GameObject();

        var playerMovement = testPlayer.AddComponent<PlayerMovement>();
        float yAxisValue = 1.0f;
        playerMovement.SetYAxisMovement(yAxisValue);

        Assert.AreEqual(yAxisValue, playerMovement.GetMovementY());
    }

    [Test]
    public void PlayerMovementXAxisPositionTest()
    {
        // Arrange
        GameObject testPlayer = new GameObject();

        var playerMovement = testPlayer.AddComponent<PlayerMovement>();
        float xAxisValue = 1.0f;
        playerMovement.SetXAxisMovement(xAxisValue);

        Assert.AreEqual(xAxisValue, playerMovement.GetMovementX());
    }

}